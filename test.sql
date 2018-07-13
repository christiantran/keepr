-- DROP TABLE users;

-- CREATE TABLE users (
--     id VARCHAR(255) NOT NULL,
--     username VARCHAR(20) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     password VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),
--     UNIQUE KEY email (email)
-- );


-- DROP TABLE keeps;

-- CREATE TABLE keeps (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(20) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     authorId VARCHAR(255) NOT NULL,
--     INDEX authorId (authorId),
--     FOREIGN KEY (authorId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );


-- DROP TABLE vaults;

-- CREATE TABLE vaults (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(20) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     authorId VARCHAR(255),
--     INDEX authorId (authorId),
--     FOREIGN KEY (authorId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );


-- DROP TABLE vaultkeeps;

-- CREATE TABLE vaultkeeps (
--     id int NOT NULL AUTO_INCREMENT,
--     vaultId int NOT NULL,
--     keepId int NOT NULL,
--     userId VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id),
--     INDEX (vaultId, keepId),
--     INDEX (userId),

--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (vaultId)
--         REFERENCES vaults(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (keepId)
--         REFERENCES keeps(id)
--         ON DELETE CASCADE
-- )


-- USE THIS LINE FOR GET KEEPS BY VAULTID

-- SELECT * FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = 2)

-- DELETE FROM keeps WHERE id = 1,

-- DELETE FROM vaults WHERE id = 2,
-- DELETE FROM users WHERE id = 1


-- CREATE TABLE posts (
--   id int NOT NULL AUTO_INCREMENT,
--   body VARCHAR(255),
--   title VARCHAR(255) NOT NULL,
--   authorId VARCHAR(255) NOT NULL,

--   PRIMARY KEY (id),
--   INDEX (authorId),

--   FOREIGN KEY (authorId)
--     REFERENCES users(id)
-- );


-- CREATE TABLE userfavs (
--   id int NOT NULL AUTO_INCREMENT,
--   postId int NOT NULL,
--   userId VARCHAR(255) NOT NULL,

--   PRIMARY KEY (id),
--   INDEX (userid),

--   FOREIGN KEY (postId)
--     REFERENCES posts(id)
--     ON DELETE CASCADE,

--   FOREIGN KEY (userId)
--     REFERENCES users(id)
--     ON DELETE CASCADE
-- );