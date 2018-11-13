--Visos lentelės, kuriose yra bent du to paties tipo stulpeliai.
SELECT A.table_name
FROM Information_Schema.Tables A, Information_Schema.Columns B
WHERE B.table_schema = A.table_schema AND A.table_name = B.table_name
GROUP BY B.data_type, A.table_schema, A.table_name
HAVING (COUNT(*) > 1);

	
