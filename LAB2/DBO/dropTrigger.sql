DROP TRIGGER checkingCodeLength ON CSET;
DROP TRIGGER checkingSpecimenNumberViolation ON Specimen;
DROP TRIGGER checkingSpecimenNameViolation ON Specimen;
DROP FUNCTION ExactSetCodeLength() CASCADE;
DROP FUNCTION SpecimenNumberAuthentification() CASCADE;
DROP FUNCTION SpecimenNameAuthentification() CASCADE;