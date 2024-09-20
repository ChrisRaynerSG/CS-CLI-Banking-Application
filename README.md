# CS-CLI-Banking-Application

## Contents

1. [Overview](#overview)
2. [Setup](#setup)
3. [Creating the database](#mysql-database)

## Overview

## Setup

### MySql Database
This banking application stores data within a MySql database, which must be created prior to using the application by following the below steps:

1. Install MySql if not present on your machine
2. Create the database
   ```SQL
   CREATE SCHEMA banking_app;
   ```
4. Create the users table
   ```SQL
   create table users
    (
        user_id       int auto_increment primary key,
        first_name    varchar(255) not null,
        last_name     varchar(255) not null,
        email         varchar(255) not null,
        password      varchar(255) not null,
        date_of_birth date         not null,
        address1      varchar(255) null,
        address2      varchar(255) null,
        address3      varchar(255) null,
        city          varchar(30)  null,
        county        varchar(30)  null,
        post_code     varchar(8)   null
    );
   ```
5. Create the banks table
   ```SQL
    CREATE TABLE banks
    (
        bank_id   INT auto_increment PRIMARY KEY,
        bank_name VARCHAR(255) NOT NULL,
        bank_code VARCHAR(8)   NOT NULL,
        address1  VARCHAR(255) NOT NULL,
        address2  VARCHAR(255) NOT NULL,
        address3  VARCHAR(255) NOT NULL,
        city      VARCHAR(50)  NOT NULL,
        county    VARCHAR(50)  NOT NULL,
        postcode  VARCHAR(8)   NOT NULL
    );
   ```
6. Create the account types table
   ```SQL
       CREATE TABLE account_types
      (
          account_type_id INT auto_increment PRIMARY KEY,
          account_type_name VARCHAR(50) NOT NULL,
          account_type_interest DOUBLE NOT NULL
      );
   ```
7. Create the accounts table
   ```SQL
   create table accounts
    (
        account_id      INT           not null primary key,
        user_id         INT           not null,
        bank_id         INT            not null,
        account_type_id INT            not null,
        account_number  VARCHAR(8)     not null,
        balance         DECIMAL(18, 2) not null,
        created_at      date           not null,
        constraint accounts_account_types_account_type_id_fk foreign key (account_type_id) references account_types (account_type_id),
        constraint accounts_banks_bank_id_fk foreign key (bank_id) references banks (bank_id),
        constraint accounts_users_user_id_fk foreign key (user_id) references users (user_id)
    );
   ```
8. Create the transactions table
   ```SQL
   create table transactions
    (
        transaction_id   INT auto_increment primary key,
        transaction_type VARCHAR(50)    not null,
        amount           DECIMAL(18, 2) not null,
        transaction_date DATE           not null,
        account_id       INT            not null,
        transaction_desc VARCHAR(255)   null,
        constraint transactions_accounts_account_id_fk foreign key (account_id) references accounts (account_id)
    );
   ```
9. Create the cards table
    ```SQL
    create table cards
    (
        card_id         int auto_increment primary key,
        account_id      int         not null,
        card_number     char(16)    not null,
        cvv             char(3)     not null,
        expiration_date date        not null,
        issue_date      date        not null,
        card_type       varchar(20) null,
        constraint cards_accounts_account_id_fk foreign key (account_id) references accounts (account_id),
        constraint chk_card_number check (card_number REGEXP '^[0-9]{16}$'),
    	  constraint chk_cvv check check (cvv REGEXP '^[0-9]{3}$')
    );
    ```
10. Populate the database with different banks and account types:

    - Bank examples:
       ```SQL
      INSERT INTO banking_app.banks (bank_name, bank_code, address1, address2, address3, city, county, postcode)
      VALUES ('Barcwest', '50-12-56', '5', 'Nottireal Road', 'Wigham', 'Nottireal', 'Notton', 'NO9 1WG');
      
      INSERT INTO banking_app.banks (bank_name, bank_code, address1, address2, address3, city, county, postcode)
      VALUES ('Barcwest', '12-48-54', '21', 'Gunners Street', 'Greenville', 'Breakton', 'Centshire', 'BR21 1GD');

      INSERT INTO banking_app.banks (bank_name, bank_code, address1, address2, address3, city, county, postcode)
      VALUES ('Barcwest', '13-18-14', 'Bank Building', '15', 'High Street', 'Madeupton', 'Madeupshire', 'MD1 1UP');
       ```

    - Account type examples:
      ```SQL
      INSERT INTO banking_app.account_types (account_type_name, account_type_interest)
      VALUES ('current', 1.67);
         
      INSERT INTO banking_app.account_types (account_type_name, account_type_interest)
      VALUES ('savings', 3.98);
         
      INSERT INTO banking_app.account_types (account_type_name, account_type_interest)
      VALUES ('isa', 5.13);
         
      INSERT INTO banking_app.account_types (account_type_name, account_type_interest)
      VALUES ('deluxe_savings', 9.65);
       ```
    
   
