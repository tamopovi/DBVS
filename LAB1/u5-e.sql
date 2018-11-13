
SELECT SUM(CAST ((CASE WHEN table_type = 'VIEW' THEN 1 ELSE 0 END) AS INTEGER)) AS "Virtualios",
SUM(CAST ((CASE WHEN table_type = 'BASE TABLE' THEN 1 ELSE 0 END) AS INTEGER))  AS "Bazines", COUNT (*) AS "Visos"
FROM Information_Schema.Tables;
