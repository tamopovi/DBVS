--substr arba split
CREATE VIEW NoTextExtraNames AS
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
FROM Card;

CREATE MATERIALIZED VIEW CardAppearedInSets AS
	SELECT Name as "Card Name", COUNT (*) AS "Set Count" FROM Specimen 
	GROUP BY Name
	ORDER BY 1
WITH NO DATA;