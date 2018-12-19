DROP TRIGGER checkingCodeLength ON pota4187.CSET;
DROP TRIGGER checkingSpecimenNumberViolation ON pota4187.Specimen;
DROP TRIGGER checkingSpecimenNameViolation ON pota4187.Specimen;
DROP FUNCTION pota4187.ExactSetCodeLength() CASCADE;
DROP FUNCTION pota4187.SpecimenNumberAuthentification() CASCADE;
DROP FUNCTION pota4187.SpecimenNameAuthentification() CASCADE;