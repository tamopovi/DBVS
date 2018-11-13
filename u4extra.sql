-- isvesti skaitytojus, skaitomu knygu pavadinimus, jeigu skaitytojo amzius yra vyresnis nei tos knygos skaitytoju amziaus vidurkis
WITH	Knygos_skaitytoju_vidurkis(ISBN,Vidurkis) AS
	(SELECT A.ISBN, 
		AVG(age(current_date,Stud.Skaitytojas.Gimimas))
	FROM Stud.Skaitytojas, Stud.Egzempliorius A
	WHERE Stud.Skaitytojas.Nr = A.Skaitytojas
	GROUP BY A.ISBN)

SELECT	Stud.Skaitytojas.Pavarde, Stud.Knyga.Pavadinimas
FROM	Knygos_skaitytoju_vidurkis B, Stud.Skaitytojas, Stud.Knyga, Stud.Egzempliorius
WHERE	Stud.Knyga.ISBN = Stud.Egzempliorius.ISBN AND
 Stud.Skaitytojas.Nr = Stud.Egzempliorius.Skaitytojas
AND age(current_date,Stud.Skaitytojas.Gimimas) > B.Vidurkis
	AND Stud.Egzempliorius.ISBN = B.ISBN;

