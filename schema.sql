-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`DRZAVA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`DRZAVA` (
  `idDrzave` INT NOT NULL AUTO_INCREMENT,
  `Naziv_drzave` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idDrzave`),
  UNIQUE INDEX `idDrzave_UNIQUE` (`idDrzave` ASC) VISIBLE,
  UNIQUE INDEX `Naziv_drzave_UNIQUE` (`Naziv_drzave` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`KORISNIK`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`KORISNIK` (
  `JMBG` CHAR(13) NOT NULL,
  `Ime` VARCHAR(45) NOT NULL,
  `Prezime` VARCHAR(45) NOT NULL,
  `Datum_rodjenja` DATE NOT NULL,
  `Broj_telefona` CHAR(11) NOT NULL,
  `Email` VARCHAR(45) NOT NULL,
  `Korisnicko_ime` VARCHAR(45) NOT NULL,
  `Lozinka` VARCHAR(45) NOT NULL,
  `Tema` INT NOT NULL,
  `Rola` INT NOT NULL,
  PRIMARY KEY (`JMBG`),
  UNIQUE INDEX `JMBG_UNIQUE` (`JMBG` ASC) VISIBLE,
  UNIQUE INDEX `KorisnickoIMe_UNIQUE` (`Korisnicko_ime` ASC) VISIBLE,
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE,
  UNIQUE INDEX `Broj_telefona_UNIQUE` (`Broj_telefona` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`DESTINACIJA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`DESTINACIJA` (
  `idDestinacije` INT NOT NULL AUTO_INCREMENT,
  `Grad` VARCHAR(45) NOT NULL,
  `Opis` VARCHAR(1000) NOT NULL,
  `DRZAVA_idDrzave` INT NOT NULL,
  `Slika` LONGBLOB NOT NULL,
  PRIMARY KEY (`idDestinacije`),
  UNIQUE INDEX `idDestinacije_UNIQUE` (`idDestinacije` ASC) VISIBLE,
  INDEX `fk_DESTINACIJA_DRZAVA_idx` (`DRZAVA_idDrzave` ASC) VISIBLE,
  CONSTRAINT `fk_DESTINACIJA_DRZAVA`
    FOREIGN KEY (`DRZAVA_idDrzave`)
    REFERENCES `mydb`.`DRZAVA` (`idDrzave`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`ARANZMAN`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`ARANZMAN` (
  `idAranzmana` INT NOT NULL AUTO_INCREMENT,
  `Datum_polaska` DATE NOT NULL,
  `Datum_povratka` DATE NOT NULL,
  `Cijena` DECIMAL(6,2) NOT NULL,
  `Broj_mjesta` INT NOT NULL,
  `DESTINACIJA_idDestinacije` INT NOT NULL,
  `KORISNIK_JMBG` CHAR(13) NOT NULL,
  PRIMARY KEY (`idAranzmana`),
  UNIQUE INDEX `idAranzmana_UNIQUE` (`idAranzmana` ASC) VISIBLE,
  INDEX `fk_ARANZMAN_DESTINACIJA1_idx` (`DESTINACIJA_idDestinacije` ASC) VISIBLE,
  INDEX `fk_ARANZMAN_KORISNIK1_idx` (`KORISNIK_JMBG` ASC) VISIBLE,
  CONSTRAINT `fk_ARANZMAN_DESTINACIJA1`
    FOREIGN KEY (`DESTINACIJA_idDestinacije`)
    REFERENCES `mydb`.`DESTINACIJA` (`idDestinacije`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ARANZMAN_KORISNIK1`
    FOREIGN KEY (`KORISNIK_JMBG`)
    REFERENCES `mydb`.`KORISNIK` (`JMBG`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`REZERVACIJA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`REZERVACIJA` (
  `idRezervacije` INT NOT NULL AUTO_INCREMENT,
  `DatumRezervacije` DATE NOT NULL,
  `KORISNIK_JMBG` CHAR(13) NOT NULL,
  PRIMARY KEY (`idRezervacije`),
  UNIQUE INDEX `idRezervacije_UNIQUE` (`idRezervacije` ASC) VISIBLE,
  INDEX `fk_REZERVACIJA_KORISNIK1_idx` (`KORISNIK_JMBG` ASC) VISIBLE,
  CONSTRAINT `fk_REZERVACIJA_KORISNIK1`
    FOREIGN KEY (`KORISNIK_JMBG`)
    REFERENCES `mydb`.`KORISNIK` (`JMBG`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`REZERVACIJA_STAVKA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`REZERVACIJA_STAVKA` (
  `ARANZMAN_idAranzmana` INT NOT NULL,
  `REZERVACIJA_idRezervacije` INT NOT NULL,
  `Kolicina` INT NOT NULL,
  PRIMARY KEY (`ARANZMAN_idAranzmana`, `REZERVACIJA_idRezervacije`),
  INDEX `fk_ARANZMAN_has_REZERVACIJA_REZERVACIJA1_idx` (`REZERVACIJA_idRezervacije` ASC) VISIBLE,
  INDEX `fk_ARANZMAN_has_REZERVACIJA_ARANZMAN1_idx` (`ARANZMAN_idAranzmana` ASC) VISIBLE,
  CONSTRAINT `fk_ARANZMAN_has_REZERVACIJA_ARANZMAN1`
    FOREIGN KEY (`ARANZMAN_idAranzmana`)
    REFERENCES `mydb`.`ARANZMAN` (`idAranzmana`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ARANZMAN_has_REZERVACIJA_REZERVACIJA1`
    FOREIGN KEY (`REZERVACIJA_idRezervacije`)
    REFERENCES `mydb`.`REZERVACIJA` (`idRezervacije`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`KUPOVINA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`KUPOVINA` (
  `idKupovine` INT NOT NULL AUTO_INCREMENT,
  `KORISNIK_JMBG` CHAR(13) NOT NULL,
  PRIMARY KEY (`idKupovine`),
  UNIQUE INDEX `idKupovine_UNIQUE` (`idKupovine` ASC) VISIBLE,
  INDEX `fk_KUPOVINA_KORISNIK1_idx` (`KORISNIK_JMBG` ASC) VISIBLE,
  CONSTRAINT `fk_KUPOVINA_KORISNIK1`
    FOREIGN KEY (`KORISNIK_JMBG`)
    REFERENCES `mydb`.`KORISNIK` (`JMBG`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`KUPOVINA_STAVKA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`KUPOVINA_STAVKA` (
  `KUPOVINA_idKupovine` INT NOT NULL,
  `ARANZMAN_idAranzmana` INT NOT NULL,
  `Kolicina` INT NOT NULL,
  PRIMARY KEY (`KUPOVINA_idKupovine`, `ARANZMAN_idAranzmana`),
  INDEX `fk_KUPOVINA_has_ARANZMAN_ARANZMAN1_idx` (`ARANZMAN_idAranzmana` ASC) VISIBLE,
  INDEX `fk_KUPOVINA_has_ARANZMAN_KUPOVINA1_idx` (`KUPOVINA_idKupovine` ASC) VISIBLE,
  CONSTRAINT `fk_KUPOVINA_has_ARANZMAN_KUPOVINA1`
    FOREIGN KEY (`KUPOVINA_idKupovine`)
    REFERENCES `mydb`.`KUPOVINA` (`idKupovine`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_KUPOVINA_has_ARANZMAN_ARANZMAN1`
    FOREIGN KEY (`ARANZMAN_idAranzmana`)
    REFERENCES `mydb`.`ARANZMAN` (`idAranzmana`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
