--Konkrečiam naudotojui, skaičius virtualių lentelių, kurioms jis turi teisę rašyti užklausas.
SELECT grantee, COUNT (*) 
FROM Information_Schema.Table_Privileges P, Information_Schema.Views V
WHERE P.table_catalog = V.table_catalog
AND p.table_schema = V.table_schema
AND P.privilege_type = 'SELECT'
AND grantee = 'pota4187'
AND P.Table_Name = V.Table_Name
GROUP BY grantee;
