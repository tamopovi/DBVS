--Kiekvienai schemai visų priklausančių jai lentelių skaičius.
SELECT schema_name, COUNT (*) FROM Information_Schema.Schemata S, Information_Schema.Tables T
WHERE S.schema_name = T.table_schema
GROUP BY schema_name;
