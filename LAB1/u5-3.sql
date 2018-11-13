--Konkrečiam duomenų tipui, domenų, sukurtų naudojant tą duomenų tipą, skaičius.
SELECT COUNT (*)
FROM Information_Schema.domains
WHERE data_type = 'integer'
GROUP BY data_type;
