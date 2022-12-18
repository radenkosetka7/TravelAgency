use mydb;

delimiter $$
create procedure novi_korisnik(
in jmbg char(13), in ime char(20), in prezime char(20), in datum DATE, in broj char(11),
 in mail char(20), in korisnicko_ime char(20), in lozinka char(20), in tema int,in rola int)
 begin
 insert into korisnik values(jmbg,ime,prezime,datum,broj,mail,korisnicko_ime,lozinka,tema,rola);
 end $$
delimiter ;


delimiter $$
create procedure novi_aranzman(
in id int, in polazak DATE, in povratak DATE, in cijena decimal,
 in broj int,in destinacija int,in jmbg char(13))
 begin
 insert into aranzman values(id,polazak,povratak,cijena,broj,destinacija,jmbg);
 end $$
delimiter;

delimiter $$
create trigger provjeri_mail_korisnika before
insert on korisnik
for each row
begin
if (new.Email not regexp '(.){1,}\@(.){1,}\..{3}') 
then
signal sqlstate '45000'
set message_text='greska:
			neispravan mail!';
end if;
end; $$
delimiter ;

delimiter $$
create trigger provjera_telefona_korisnika before
insert on korisnik
for each row
begin
if (new.Broj_telefona not regexp '[0-9]{3}\/[0-9]{3}\-[0-9]{3}')
then
signal sqlstate '45000'
set message_text= 'greska:
					neispravan broj!';
end if;
end; $$
delimiter ;



delimiter $$
CREATE trigger provjera_ispravnosti_datuma before
insert on aranzman
for each row
begin
if new.Datum_polaska >= new.Datum_povratka
then
signal sqlstate '45000'
set message_text= 'greska:
					neispravan datum!';
end if;
end;$$
delimiter ;

delimiter $$
create trigger provjeri_slobodna_mjesta before
insert on aranzman
for each row
begin
if new.Broj_mjesta <=0
then
signal sqlstate '45000'
set message_text='greska:
				nema vise raspolozivih mjesta!';
end if;
end; $$
delimiter;

delimiter $$
create trigger raspoloziva_mjesta_nakon_rezervacije after
insert on rezervacija_stavka
for each row
update aranzman
set Broj_mjesta=Broj_mjesta-new.kolicina
where idAranzmana=new.ARANZMAN_idAranzmana;
$$
delimiter ;

delimiter $$
create trigger raspoloziva_mjesta_nakon_kupovine after
insert on kupovina_stavka
for each row
update aranzman
set Broj_mjesta=Broj_mjesta-new.kolicina
where idAranzmana=new.ARANZMAN_idAranzmana;
$$
delimiter ;

