-- Kiekvienai knygai (ISBN ir pavadinimas) jos visų skaitytojų skaičius ir visų nepaimtų egzempliorių skaičius.

SELECT Stud.Knyga.Pavadinimas, Stud.Knyga.ISBN, COUNT (A.Paimta) AS Skaitytoju_sk, COUNT (*) -COUNT (A.Paimta) AS like_egz
FROM Stud.Knyga, Stud.Egzempliorius A
WHERE Stud.Knyga.ISBN = A.ISBN
GROUP BY Stud.Knyga.Pavadinimas, Stud.Knyga.ISBN
HAVING (COUNT (*) - COUNT(A.Paimta) > 2);
