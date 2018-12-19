--Artists (Id, Name, Surname)
INSERT INTO Artist VALUES (DEFAULT, 'Terese', 'Nielsen');
INSERT INTO Artist VALUES (DEFAULT, 'John', 'Avon');
INSERT INTO Artist VALUES (DEFAULT, 'Raymond', 'Swanland');
INSERT INTO Artist VALUES (DEFAULT, 'Chase', 'Stone');
INSERT INTO Artist VALUES (DEFAULT, 'James', 'Paick');
INSERT INTO Artist VALUES (DEFAULT, 'Steve', 'Prescott');
INSERT INTO Artist VALUES (DEFAULT, 'Zhezou', 'Chen');
INSERT INTO Artist VALUES (DEFAULT, 'Mathias', 'Kollros');
INSERT INTO Artist VALUES (DEFAULT, 'Steve', 'Argyle');
INSERT INTO Artist VALUES (DEFAULT, 'Christine', 'Choi');
INSERT INTO Artist VALUES (DEFAULT, 'Jonas', 'De Ro');
INSERT INTO Artist VALUES (DEFAULT, 'Josh', 'Hass');
INSERT INTO Artist VALUES (DEFAULT, 'Lucas', 'Graciano');
INSERT INTO Artist VALUES (DEFAULT, 'Tyler', 'Jacobson');

--Paintings
INSERT INTO Painting VALUES ('ancient_crab0', 5);
INSERT INTO Painting VALUES ('ancient_crab1',6);
INSERT INTO Painting VALUES ('blazing_volley0',7);
INSERT INTO Painting VALUES ('cancel0', 8);
INSERT INTO Painting VALUES ('cancel1', 8);
INSERT INTO Painting VALUES ('enigma_drake0', 9);
INSERT INTO Painting VALUES ('bontu0', 4);
INSERT INTO Painting VALUES ('evolving_wilds0', 10);
INSERT INTO Painting VALUES ('evolving_wilds1', 11);
INSERT INTO Painting VALUES ('essence_scatter0', 12);
INSERT INTO Painting VALUES ('fetid_pools0', 11);
INSERT INTO Painting VALUES ('fling0', 13);
INSERT INTO Painting VALUES ('plains0', 2);
INSERT INTO Painting VALUES ('anticipate0',14);
INSERT INTO Painting VALUES ('plains1', 8);
INSERT INTO Painting VALUES ('tectonic_rift0',2);
INSERT INTO Painting VALUES ('plains2', 5);



--Cards (name, Type, cost, CText, Color)
INSERT INTO Card VALUES ('Ancient Crab', 'Creature', 3, NULL, 'U');
INSERT INTO Card VALUES ('Blazing Volley', 'Sorcery', 1, 'Blazing Volley deals 1 damage to each creature your opponents control.', 'R');
INSERT INTO Card VALUES ('Cancel', 'Instant', 3, 'Counter target spell.', 'U');
INSERT INTO Card VALUES ('Enigma Drake', 'Creature', 3, 'Flying\nEnigma Drakes power is equal to the number of instant and sorcery cards in your graveyard.', 'UR');
INSERT INTO Card VALUES ('Bontu the Glorified', 'Creature', 3, 'Menace, indestructible\nBontu the Glorified cant attack or block unless a creature died under your control this turn.\n1B, Sacrifice another creature: Scry 1. Each opponent loses 1 life and you gain 1 life.', 'B');
INSERT INTO Card VALUES ('Evolving Wilds', 'Land', 0, 'Tap, Sacrifice Evolving Wilds: Search your library for a basic land card, put it onto the battlefield tapped, then shuffle your library.', DEFAULT);
INSERT INTO Card VALUES ('Essence Scatter', 'Instant', 2, 'Counter target creature spell.', 'U');
INSERT INTO Card VALUES ('Fetid Pools', 'Land', 0, '(Tap: Add Blue or Black.)\nFetid Pools enters the battlefield tapped.\nCycling 2 (2, Discard this card: Draw a card.)','UB');
INSERT INTO Card VALUES ('Fling', 'Instant', 2, 'As an additional cost to cast this spell, sacrifice a creature.\nFling deals damage equal to the sacrificed creature''s power to any target.','R');
INSERT INTO Card VALUES ('Plains', 'Basic Land - Plains', DEFAULT, 'W', DEFAULT);
INSERT INTO Card VALUES ('Anticipate', 'Instant', 2, 'Look at the top three cards of your library. Put one of them into your hand and the rest on the bottom of your library in any order.','U');
INSERT INTO Card VALUES ('Tectonic Rift', 'Sorcery', 4, 'Destroy target land. Creatures without flying can''t block this turn.', 'R');


--Card Sets (code, CAmount, Year, Name)
INSERT INTO CSET VALUES ('AKH', 269, 2017, 'Amonkhet');
INSERT INTO CSET VALUES ('OOW', 184, 2016, 'Oath of the Gatewatch');
INSERT INTO CSET VALUES ('XLN', 279, 2017, 'Ixalan');
INSERT INTO CSET VALUES ('M19', 280, 2018, 'Core Set 2019');
INSERT INTO CSET VALUES ('RIX', 196, 2018, 'Rivals of Ixalan');
--Testing setCodeLength must be 3
--INSERT INTO CSET VALUES ('RC', 196, 2018, 'Rivals of Ixalawdn');

--Card Specimen  (nr, painting, set, FText, Name)
INSERT INTO Specimen VALUES (50, 'ancient_crab1', 'OOW', 'After the fall of Sea Gate and the draining of the Halimar basin, the crab set off to find a new home.','Ancient Crab');
INSERT INTO Specimen VALUES (40, 'ancient_crab0', 'AKH', 'The banks of the Luxa River attract all manner of predator but only the most resilient of prey.', 'Ancient Crab');
INSERT INTO Specimen VALUES (119, 'blazing_volley0', 'AKH', 'The arrows fell like fiery rain, and for a moment, the sky itself seemed to burn.', 'Blazing Volley');
INSERT INTO Specimen VALUES (44, 'cancel0', 'AKH','Let me try one of Kefnets puzzles. This one was too easy.', 'Cancel');
INSERT INTO Specimen VALUES (47, 'cancel1', 'XLN','Hold your fire, obviously.', 'Cancel');
INSERT INTO Specimen VALUES (48, 'cancel0', 'M19','I decide what stands in my way', 'Cancel');
INSERT INTO Specimen VALUES (198, 'enigma_drake0', 'AKH', 'Many initiates believe it possesses secrets known only to Kefnet himself. Many have become meals trying to learn them.', 'Enigma Drake');
INSERT INTO Specimen VALUES (216, 'enigma_drake0', 'M19', 'Many initiates believe it possesses secrets known only to Kefnet himself. Many have become meals trying to learn them.', 'Enigma Drake');
INSERT INTO Specimen VALUES (82, 'bontu0', 'AKH', NULL, 'Bontu the Glorified');
INSERT INTO Specimen VALUES (242, 'evolving_wilds0', 'AKH', 'Don''t you ever wonder what lies beyond the Hekma? Beyond the reach of the gods? Beyond the horns on the horizon?','Evolving Wilds');
INSERT INTO Specimen VALUES (186, 'evolving_wilds1', 'RIX', 'The Sun Empire bends nature—rivers, mountainsides, dinosaurs—to its unyielding will.','Evolving Wilds');
INSERT INTO Specimen VALUES (52, 'essence_scatter0', 'AKH', 'Dependence on luck is anathema to Kefnet''s rigorous studies. Those who hope to escape his maze by chance never succeed.', 'Essence Scatter');
INSERT INTO Specimen VALUES (54, 'essence_scatter0', 'M19', 'Dependence on luck is anathema to Kefnet''s rigorous studies. Those who hope to escape his maze by chance never succeed.', 'Essence Scatter');
INSERT INTO Specimen VALUES (243, 'fetid_pools0', 'AKH', NULL, 'Fetid Pools');
INSERT INTO Specimen VALUES (261, 'plains0', 'M19', NULL, 'Plains');
INSERT INTO Specimen VALUES (44, 'anticipate0', 'M19', 'Divining the future is easy when you hold the power to sway it.', 'Anticipate');
INSERT INTO Specimen VALUES (262, 'plains1', 'M19', NULL, 'Plains');
INSERT INTO Specimen VALUES (132, 'fling0', 'AKH', NULL, 'Fling');
INSERT INTO Specimen VALUES (162, 'tectonic_rift0', 'M19','"You will kneel before me, even if I have to split the earth under your feet!"
—Ash Kronor, Keldon warlord', 'Tectonic Rift');
--NAME TRIGGERS
--INSERT INTO Specimen VALUES (264, 'plains2', 'M19', NULL, 'Plains');
--INSERT INTO Specimen VALUES (131, 'fling0', 'AKH', NULL, 'Fling');
--INSERT INTO Specimen VALUES (240, 'fetid_pools0', 'AKH', NULL, 'Fetid Pools');
--SET CARD AMOUNT TRIGGERS
--INSERT INTO Specimen VALUES (1000, 'plains2', 'M19', NULL, 'Plains');


