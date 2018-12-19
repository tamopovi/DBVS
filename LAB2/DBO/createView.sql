--substr arba split
CREATE VIEW pota4187.ExtraCardInfo AS
	SELECT Name, Type, Cost,
	CASE 	WHEN substr(Color,1,1) = 'W' THEN 'White'
			WHEN substr(Color,1,1) = 'U' THEN 'Blue'
			WHEN substr(Color,1,1) = 'B' THEN 'Black'
			WHEN substr(Color,1,1) = 'R' THEN 'Red'
			WHEN substr(Color,1,1) = 'G' THEN 'Green'
			WHEN substr(Color,1,1) = 'C' THEN 'Colorless'
	END 
	||
	CASE WHEN length(color) > 1 
		THEN
		CASE 	WHEN substr(Color,2,1) = 'W' THEN ' White'
				WHEN substr(Color,2,1) = 'U' THEN ' Blue'
				WHEN substr(Color,2,1) = 'B' THEN ' Black'
				WHEN substr(Color,2,1) = 'R' THEN ' Red'
				WHEN substr(Color,2,1) = 'G' THEN ' Green'
				WHEN substr(Color,2,1) = 'C' THEN ' Colorless'
		END
		ELSE ''		
		END
	||
		CASE WHEN length(color) = 3 
		THEN
		CASE 	WHEN substr(Color,3,1) = 'W' THEN ' White'
				WHEN substr(Color,3,1) = 'U' THEN ' Blue'
				WHEN substr(Color,3,1) = 'B' THEN ' Black'
				WHEN substr(Color,3,1) = 'R' THEN ' Red'
				WHEN substr(Color,3,1) = 'G' THEN ' Green'
				WHEN substr(Color,3,1) = 'C' THEN ' Colorless'
		END
		ELSE ''
		END AS Color
FROM pota4187.Card;

CREATE MATERIALIZED VIEW pota4187.CardAppearedInSets AS
	SELECT Name as "Card Name", COUNT (*) AS "Set Count" FROM pota4187.Specimen 
	GROUP BY Name
	ORDER BY 1
WITH NO DATA;

CREATE MATERIALIZED VIEW pota4187.TypeStatistics AS
	SELECT A.Type, B.Color, COUNT(*) FROM pota4187.Card A, pota4187.ExtraCardInfo B 
	WHERE A.Name = B.Name
	GROUP BY A.Type, B.Color
	ORDER BY 3 DESC
WITH NO DATA;
--dont forget to REFRESH MATERIALIZED VIEW TypeStatistics;