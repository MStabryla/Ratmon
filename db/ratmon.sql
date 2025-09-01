CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;
CREATE TABLE "Mas2Set" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Mas2Set" PRIMARY KEY AUTOINCREMENT,
    "C" REAL NOT NULL,
    "Humidity" REAL NOT NULL
);

CREATE TABLE "Mouse2_Config" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Mouse2_Config" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Threshold" REAL NOT NULL
);

CREATE TABLE "Mouse2B_Config" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Mouse2B_Config" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Threshold" REAL NOT NULL,
    "WireLength" REAL NOT NULL
);

CREATE TABLE "Mouse2BSet" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Mouse2BSet" PRIMARY KEY AUTOINCREMENT,
    "V" REAL NOT NULL,
    "Ω" REAL NOT NULL,
    "LeakLocation" REAL NOT NULL
);

CREATE TABLE "Mouse2Set" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Mouse2Set" PRIMARY KEY AUTOINCREMENT,
    "V" REAL NOT NULL,
    "Ω" REAL NOT NULL
);

CREATE TABLE "MouseCombo_Config" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_MouseCombo_Config" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Threshold" REAL NOT NULL
);

CREATE TABLE "MouseComboSet" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_MouseComboSet" PRIMARY KEY AUTOINCREMENT,
    "V" REAL NOT NULL,
    "Ω" REAL NOT NULL
);

CREATE TABLE "Reflectogram" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Reflectogram" PRIMARY KEY AUTOINCREMENT,
    "SeriesNumber" INTEGER NOT NULL,
    "Bytes" BLOB NOT NULL,
    "MouseComboId" INTEGER NULL,
    CONSTRAINT "FK_Reflectogram_MouseComboSet_MouseComboId" FOREIGN KEY ("MouseComboId") REFERENCES "MouseComboSet" ("Id")
);

CREATE INDEX "IX_Reflectogram_MouseComboId" ON "Reflectogram" ("MouseComboId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250831114750_Init', '9.0.8');

COMMIT;

