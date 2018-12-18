CREATE FUNCTION ExactSetCodeLength() RETURNS "trigger" AS $$
DECLARE codeLength				SMALLINT;
DECLARE exactLength				SMALLINT := 3;
	BEGIN
	--NEW.table_name 			:= TG_ARGV[0];
	--NEW.column_name 			:= TG_ARGV[1];
		SELECT char_length(NEW.Code) INTO codeLength FROM CSET;
		
		IF codeLength != exactLength
			THEN RAISE EXCEPTION 'SET CODE MUST BE CONTAIN EXACTLY % CHARACTERS! ACTUAL LENGTH: %', exactLength , codeLength;
		END IF;
		RETURN NEW;
		
	END;
$$
LANGUAGE PLPGSQL;


CREATE FUNCTION SpecimenNumberAuthentification() RETURNS "trigger" AS $$
DECLARE specimenNr				SMALLINT;
Declare setSize					SMALLINT;
	BEGIN
		
		SELECT CAmount INTO setSize FROM CSET WHERE CSET.Code = NEW.SetCode;
		IF NEW.Nr > setSize
			THEN RAISE EXCEPTION 'SPECIMEN NUMBER CANNOT BE GREATER THAN SET CARD AMOUNT';
		END IF;
		RETURN NEW;
	END;
$$
LANGUAGE PLPGSQL;


CREATE TRIGGER checkingCodeLength
	BEFORE INSERT OR UPDATE ON CSET
	FOR EACH ROW EXECUTE PROCEDURE ExactSetCodeLength();
	
CREATE TRIGGER checkingSpecimenNumberViolation
	BEFORE INSERT OR UPDATE ON Specimen
	FOR EACH ROW EXECUTE PROCEDURE SpecimenNumberAuthentification();