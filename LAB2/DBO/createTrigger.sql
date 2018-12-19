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
	
CREATE TRIGGER checkingSpecimenNumberViolation
	BEFORE INSERT OR UPDATE ON pota4187.Specimen
	FOR EACH ROW EXECUTE PROCEDURE pota4187.SpecimenNumberAuthentification();
	
CREATE TRIGGER checkingSpecimenNameViolation
	BEFORE INSERT OR UPDATE ON pota4187.Specimen
	FOR EACH ROW EXECUTE PROCEDURE pota4187.SpecimenNameAuthentification();