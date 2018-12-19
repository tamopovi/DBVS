CREATE FUNCTION pota4187.ExactSetCodeLength() RETURNS "trigger" AS $$
DECLARE codeLength				SMALLINT;
DECLARE exactLength				SMALLINT := 3;
	BEGIN
	--NEW.table_name 			:= TG_ARGV[0];
	--NEW.column_name 			:= TG_ARGV[1];
		SELECT char_length(NEW.Code) INTO codeLength FROM pota4187.CSET;
		
		IF codeLength != exactLength
			THEN RAISE EXCEPTION 'SET CODE MUST BE CONTAIN EXACTLY % CHARACTERS! ACTUAL LENGTH: %', exactLength , codeLength;
		END IF;
		RETURN NEW;
		
	END;
$$
LANGUAGE PLPGSQL;


CREATE FUNCTION pota4187.SpecimenNumberAuthentification() RETURNS "trigger" AS $$
DECLARE setSize					SMALLINT;
	BEGIN
		
		SELECT A.CAmount INTO setSize FROM pota4187.CSET A WHERE A.Code = NEW.SetCode;
		IF NEW.Nr > setSize
			THEN RAISE EXCEPTION 'SPECIMEN NUMBER CANNOT BE GREATER THAN SET CARD AMOUNT';
		END IF;
		RETURN NEW;
	END;
$$
LANGUAGE PLPGSQL;

CREATE FUNCTION pota4187.SpecimenNameAuthentification() RETURNS "trigger" AS $$
DECLARE duplicateAmount			SMALLINT;
	BEGIN
	SELECT COUNT (*) INTO duplicateAmount FROM pota4187.Specimen S, pota4187.Card C 
		WHERE S.Name = NEW.Name AND 
				C.Name = NEW.Name AND
				S.SetCode = NEW.SetCode AND
				NOT (C.Type LIKE '%Basic%');
	IF	duplicateAmount != 0
		THEN RAISE EXCEPTION 'SET CANNOT CONTAIN MORE THAN ONE SPECIMEN OF A CARD! (except Basic Lands)';
	END IF;
	RETURN NEW;
	END;
$$
LANGUAGE PLPGSQL;	

CREATE TRIGGER checkingCodeLength
	BEFORE INSERT OR UPDATE ON pota4187.CSET
	FOR EACH ROW EXECUTE PROCEDURE ExactSetCodeLength();
	
CREATE TRIGGER checkingSpecimenNumberViolation
	BEFORE INSERT OR UPDATE ON pota4187.Specimen
	FOR EACH ROW EXECUTE PROCEDURE SpecimenNumberAuthentification();
	
CREATE TRIGGER checkingSpecimenNameViolation
	BEFORE INSERT OR UPDATE ON pota4187.Specimen
	FOR EACH ROW EXECUTE PROCEDURE SpecimenNameAuthentification();