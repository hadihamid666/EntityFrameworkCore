CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Coaches" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Coaches" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "CreatedDate" TEXT NOT NULL
);

CREATE TABLE "Teams" (
    "TeamId" INTEGER NOT NULL CONSTRAINT "PK_Teams" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "CreatedDate" TEXT NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250715095731_InitialMigration', '7.0.20');

COMMIT;

BEGIN TRANSACTION;

INSERT INTO "Teams" ("TeamId", "CreatedDate", "Name")
VALUES (1, '2025-07-16 10:10:10.792762', 'Tivoli Gardens F.C.');
INSERT INTO "Teams" ("TeamId", "CreatedDate", "Name")
VALUES (2, '2025-07-16 10:10:10.7927627', 'Waterhouse F.C.');
INSERT INTO "Teams" ("TeamId", "CreatedDate", "Name")
VALUES (3, '2025-07-16 10:10:10.7927628', 'Humble Lions F.C.');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250716101010_SeedingData_Into_Teams_Table', '7.0.20');

COMMIT;

BEGIN TRANSACTION;

DELETE FROM "Teams"
WHERE "TeamId" = 1
RETURNING 1;

DELETE FROM "Teams"
WHERE "TeamId" = 2
RETURNING 1;

DELETE FROM "Teams"
WHERE "TeamId" = 3
RETURNING 1;

ALTER TABLE "Teams" ADD "Id" INTEGER NOT NULL DEFAULT 0;

ALTER TABLE "Teams" ADD "CoachId" INTEGER NOT NULL DEFAULT 0;

ALTER TABLE "Teams" ADD "CreatedBy" TEXT NULL;

ALTER TABLE "Teams" ADD "LeagueId" INTEGER NOT NULL DEFAULT 0;

ALTER TABLE "Teams" ADD "ModifiedBy" TEXT NULL;

ALTER TABLE "Teams" ADD "ModifiedDate" TEXT NOT NULL DEFAULT '0001-01-01 00:00:00';

ALTER TABLE "Coaches" ADD "CreatedBy" TEXT NULL;

ALTER TABLE "Coaches" ADD "ModifiedBy" TEXT NULL;

ALTER TABLE "Coaches" ADD "ModifiedDate" TEXT NOT NULL DEFAULT '0001-01-01 00:00:00';

ALTER TABLE "Coaches" ADD "TeamId" INTEGER NULL;

CREATE TABLE "Leagues" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Leagues" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "CreatedDate" TEXT NOT NULL,
    "ModifiedDate" TEXT NOT NULL,
    "CreatedBy" TEXT NULL,
    "ModifiedBy" TEXT NULL
);

CREATE TABLE "Matches" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Matches" PRIMARY KEY AUTOINCREMENT,
    "HomeTeamId" INTEGER NOT NULL,
    "AwayTeamId" INTEGER NOT NULL,
    "TicketPrice" TEXT NOT NULL,
    "Date" TEXT NOT NULL,
    "CreatedDate" TEXT NOT NULL,
    "ModifiedDate" TEXT NOT NULL,
    "CreatedBy" TEXT NULL,
    "ModifiedBy" TEXT NULL
);

INSERT INTO "Teams" ("Id", "CoachId", "CreatedBy", "CreatedDate", "LeagueId", "ModifiedBy", "ModifiedDate", "Name", "TeamId")
VALUES (1, 0, NULL, '2025-07-23 12:18:42.0021869', 0, NULL, '0001-01-01 00:00:00', 'Tivoli Gardens F.C.', NULL);
INSERT INTO "Teams" ("Id", "CoachId", "CreatedBy", "CreatedDate", "LeagueId", "ModifiedBy", "ModifiedDate", "Name", "TeamId")
VALUES (2, 0, NULL, '2025-07-23 12:18:42.0021876', 0, NULL, '0001-01-01 00:00:00', 'Waterhouse F.C.', NULL);
INSERT INTO "Teams" ("Id", "CoachId", "CreatedBy", "CreatedDate", "LeagueId", "ModifiedBy", "ModifiedDate", "Name", "TeamId")
VALUES (3, 0, NULL, '2025-07-23 12:18:42.0021878', 0, NULL, '0001-01-01 00:00:00', 'Humble Lions F.C.', NULL);

CREATE TABLE "ef_temp_Teams" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Teams" PRIMARY KEY AUTOINCREMENT,
    "CoachId" INTEGER NOT NULL,
    "CreatedBy" TEXT NULL,
    "CreatedDate" TEXT NOT NULL,
    "LeagueId" INTEGER NOT NULL,
    "ModifiedBy" TEXT NULL,
    "ModifiedDate" TEXT NOT NULL,
    "Name" TEXT NULL,
    "TeamId" INTEGER NULL
);

INSERT INTO "ef_temp_Teams" ("Id", "CoachId", "CreatedBy", "CreatedDate", "LeagueId", "ModifiedBy", "ModifiedDate", "Name", "TeamId")
SELECT "Id", "CoachId", "CreatedBy", "CreatedDate", "LeagueId", "ModifiedBy", "ModifiedDate", "Name", "TeamId"
FROM "Teams";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "Teams";

ALTER TABLE "ef_temp_Teams" RENAME TO "Teams";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250723121842_AddMoreEntities', '7.0.20');

COMMIT;

BEGIN TRANSACTION;

UPDATE "Teams" SET "CreatedDate" = '2025-07-23 12:19:28.3741614'
WHERE "Id" = 1
RETURNING 1;

UPDATE "Teams" SET "CreatedDate" = '2025-07-23 12:19:28.3741621'
WHERE "Id" = 2
RETURNING 1;

UPDATE "Teams" SET "CreatedDate" = '2025-07-23 12:19:28.3741622'
WHERE "Id" = 3
RETURNING 1;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250723121928_RemovedTeamId', '7.0.20');

COMMIT;

BEGIN TRANSACTION;

UPDATE "Teams" SET "CreatedDate" = '2025-07-28 09:42:22.1854165'
WHERE "Id" = 1
RETURNING 1;

UPDATE "Teams" SET "CreatedDate" = '2025-07-28 09:42:22.1854171'
WHERE "Id" = 2
RETURNING 1;

UPDATE "Teams" SET "CreatedDate" = '2025-07-28 09:42:22.1854172'
WHERE "Id" = 3
RETURNING 1;

CREATE TABLE "ef_temp_Teams" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Teams" PRIMARY KEY AUTOINCREMENT,
    "CoachId" INTEGER NOT NULL,
    "CreatedBy" TEXT NULL,
    "CreatedDate" TEXT NOT NULL,
    "LeagueId" INTEGER NOT NULL,
    "ModifiedBy" TEXT NULL,
    "ModifiedDate" TEXT NOT NULL,
    "Name" TEXT NULL
);

INSERT INTO "ef_temp_Teams" ("Id", "CoachId", "CreatedBy", "CreatedDate", "LeagueId", "ModifiedBy", "ModifiedDate", "Name")
SELECT "Id", "CoachId", "CreatedBy", "CreatedDate", "LeagueId", "ModifiedBy", "ModifiedDate", "Name"
FROM "Teams";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "Teams";

ALTER TABLE "ef_temp_Teams" RENAME TO "Teams";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250728094222_UpdateTeamTable', '7.0.20');

COMMIT;

BEGIN TRANSACTION;

INSERT INTO "Leagues" ("Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Name")
VALUES (1, NULL, '0001-01-01 00:00:00', NULL, '0001-01-01 00:00:00', 'Jamaica Premiere League');
INSERT INTO "Leagues" ("Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Name")
VALUES (2, NULL, '0001-01-01 00:00:00', NULL, '0001-01-01 00:00:00', 'English Premiere League');
INSERT INTO "Leagues" ("Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Name")
VALUES (3, NULL, '0001-01-01 00:00:00', NULL, '0001-01-01 00:00:00', 'La Liga');

UPDATE "Teams" SET "CreatedDate" = '2025-07-29 09:35:09.3764867'
WHERE "Id" = 1
RETURNING 1;

UPDATE "Teams" SET "CreatedDate" = '2025-07-29 09:35:09.3764877'
WHERE "Id" = 2
RETURNING 1;

UPDATE "Teams" SET "CreatedDate" = '2025-07-29 09:35:09.3764879'
WHERE "Id" = 3
RETURNING 1;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250729093509_SeedingLeagues', '7.0.20');

COMMIT;

