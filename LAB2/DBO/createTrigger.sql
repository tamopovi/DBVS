--TODO: fix trigger error: error invalid type name
CREATE FUNCTION ExactSetCodeLength() RETURNS "trigger" AS $$
DECLARE codeLength				SMALLINT;
	BEGIN
	DECLARE table_name 				TEXT := TG_ARGV[0];
	DECLARE column_name 				TEXT := TG_ARGV[1];
		SELECT char_length(NEW.column_name ) INTO codeLength FROM NEW.table_name;
		
		IF codeLength != exactLength
			THEN RAISE EXCEPTION 'SET CODE MUST BE CONTAIN EXACTLY % CHARACTERS! ACTUAL LENGTH: %',  $3, codeLength;
		END IF;
		RETURN NEW;
		
	END;
$$
LANGUAGE PLPGSQL;

CREATE TRIGGER checkingCodeLength
	BEFORE INSERT OR UPDATE ON CSET
	FOR EACH ROW EXECUTE PROCEDURE ExactSetCodeLength('CSET','Code',3);
