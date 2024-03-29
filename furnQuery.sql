-- Active: 1697616242142@@127.0.0.1@5432@ErrorsDB
create DATABASE "Furniture";

--Структура таблицы
CREATE TABLE "Products" (
    "ProductID" uuid default gen_random_uuid() NOT NULL,
    "ProductName" VARCHAR(255) NOT NULL,
    "ProductCode" VARCHAR(20) UNIQUE NOT NULL,
    "Unit" VARCHAR(20) NOT NULL,
    "Quantity" INTEGER NOT NULL,
    "Price" DECIMAL(10, 2) NOT NULL,
PRIMARY key("ProductID")
);

--Тестовые данные
INSERT INTO "Products" ("ProductName", "ProductCode", "Unit", "Quantity", "Price")
VALUES
    ('Стол', 'STL001', 'шт.', 10, 5000.00),
    ('Стул', 'CHR002', 'шт.', 20, 1500.00),
    ('Шкаф', 'CBN003', 'шт.', 5, 12000.00),
    ('Диван', 'SOF004', 'шт.', 8, 15000.00),
    ('Кровать', 'BED005', 'шт.', 12, 20000.00),
    ('Стеллаж', 'SHL006', 'шт.', 15, 8000.00),
    ('Столик', 'TBL007', 'шт.', 25, 3000.00),
    ('Кресло', 'ARM008', 'шт.', 18, 10000.00),
    ('Стол письменный', 'DST001', 'шт.', 15, 7000.00),
    ('Комод', 'COM002', 'шт.', 10, 8500.00),
    ('Зеркало', 'MIR003', 'шт.', 7, 3000.00),
    ('Шкаф для посуды', 'CBN004', 'шт.', 6, 11000.00),
    ('Полка для книг', 'BKS005', 'шт.', 20, 2500.00),
    ('Стул-барный', 'BAR001', 'шт.', 30, 1800.00),
    ('Компьютерный стол', 'CDS002', 'шт.', 12, 6500.00),
    ('Пенал для одежды', 'WDR003', 'шт.', 8, 7500.00),
    ('Книжный шкаф', 'BKS006', 'шт.', 15, 6000.00),
    ('Письменный стол', 'WDS007', 'шт.', 10, 8500.00);

CREATE DATABASE "ErrorsDB";

--Структура таблицы
create table "Error"(
    "ErrorID" uuid default gen_random_uuid() NOT NULL,
    "Date" timestamp with time zone not null,
    "Priority" VARCHAR(255) not null,
    "Subject" VARCHAR(255) not null,
    "Message" VARCHAR not null,
    "Status" VARCHAR(255) not null,
    "FixLink" VARCHAR(255),
PRIMARY key("ErrorID")
);