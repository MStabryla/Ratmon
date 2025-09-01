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

CREATE TABLE "Mas2_Config" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Mas2_Config" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "TemperatureThreshold" REAL NOT NULL,
    "HumidityThreshold" REAL NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250901114606_Mas2Config', '9.0.8');

CREATE TABLE "Roles" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Roles" PRIMARY KEY,
    "Name" TEXT NULL,
    "NormalizedName" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL
);

CREATE TABLE "Users" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY,
    "UserName" TEXT NULL,
    "NormalizedUserName" TEXT NULL,
    "Email" TEXT NULL,
    "NormalizedEmail" TEXT NULL,
    "EmailConfirmed" INTEGER NOT NULL,
    "PasswordHash" TEXT NULL,
    "SecurityStamp" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL,
    "PhoneNumber" TEXT NULL,
    "PhoneNumberConfirmed" INTEGER NOT NULL,
    "TwoFactorEnabled" INTEGER NOT NULL,
    "LockoutEnd" TEXT NULL,
    "LockoutEnabled" INTEGER NOT NULL,
    "AccessFailedCount" INTEGER NOT NULL
);

INSERT INTO "Roles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('38752adc-9f8a-41d8-8ea3-09688a3c36a1', NULL, 'Admin', NULL);
SELECT changes();

INSERT INTO "Roles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('9097b29e-ce94-4dae-9e82-49bb13ecebde', NULL, 'User', NULL);
SELECT changes();


INSERT INTO "Users" ("Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName")
VALUES ('95992bee-8de8-40c4-b519-09324a078a47', 0, 'd2bbcc38-a1d8-4cbb-a082-7e319e986e92', NULL, 0, 0, NULL, NULL, NULL, 'AQAAAAIAAYagAAAAEMi/bwCJSzjSsuttMTo6ERXhYAsBeVi9y4y0c9Hdhjbl3MgQVHddrf7/nd0usxAv4A==', NULL, 0, 'b9777ce6-38ad-4f3c-a46b-37c3c5188bad', 0, 'John');
SELECT changes();

INSERT INTO "Users" ("Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName")
VALUES ('f2403f8b-ebed-42d3-b5f7-d33f34cfae8d', 0, '21ed90f2-7d45-4266-9bcd-86ce600a99c8', NULL, 0, 0, NULL, NULL, NULL, 'AQAAAAIAAYagAAAAEDplFCSMmkxbAtLPmuiBpMq0WuOd5QZ4YR7cyo4o0zYp/w4CQgdoyb1y4NL5HBUFhA==', NULL, 0, 'c7453058-4ce2-4d29-bc2e-bef29f759678', 0, 'Matthew');
SELECT changes();


INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250901132654_Identity', '9.0.8');

COMMIT;

