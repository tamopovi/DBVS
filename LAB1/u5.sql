--Visų duomenų bazės lentelių, virtualiųjų lentelių ir bazinių lentelių skaičiai.

WITH Papildomos (type, Skaicius) AS (SELECT A.table_type, COUNT (*) AS Skaicius FROM Information_Schema.Tables A
GROUP BY table_type),
	suma (type, Skaicius) AS (
	SELECT 'Visos', SUM(Skaicius) FROM Papildomos)
SELECT CAST(type AS TEXT), Skaicius FROM Papildomos
UNION
SELECT CAST (type AS TEXT), Skaicius FROM suma;


