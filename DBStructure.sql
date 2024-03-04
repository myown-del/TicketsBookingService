do
$$
begin
    create schema if not exists bt;
--
    create sequence if not exists bt.show_seq start with 100;
    create sequence if not exists bt.ven_seq start with 100;
    create sequence if not exists bt.hall_seq start with 100;
    create sequence if not exists bt.user_seq start with 100;
    create sequence if not exists bt.sess_seq start with 100;
    create sequence if not exists bt.tick_seq start with 100;
    create sequence if not exists bt.seat_seq start with 100;
    --
    create table if not exists bt.shows(
        id bigint default nextval('bt.show_seq'::regclass),
        title text not null,
        genre text not null,
        director text not null,
        duration text not null,
        type char(6) not null ,    
        --
        constraint show_pk primary key (id),
        constraint show_invalid_type_check
            check (type in ('play', 'movie'))                                   
    )
    without oids;

    create table if not exists bt.venues(
        id bigint default nextval('bt.ven_seq'::regclass),
        name text not null,
        address text not null,
        type char(7) not null,
        city text not null,
        --
        constraint ven_pk primary key (id),
        constraint ven_type_check
        check (type in ('theatre', 'cinema'))
    )
    without oids;

    create table if not exists bt.halls(
        id bigint default nextval('bt.hall_seq'::regclass),
        venue_id bigint not null,
        name text not null,
        --
        constraint hall_pk primary key (id)
    )
    without oids ;

    create table if not exists bt.users(
        id bigint default nextval('bt.user_seq'::regclass),
        phone_number text not null,
        password_hash text not null,
        is_admin boolean not null default false,
        name text,
        email text,
        birthday_date date,    
        --
        constraint user_pk primary key (id)
    )
    without oids ;

    create table if not exists bt.sessions(
        id bigint default nextval('bt.sess_seq'::regclass),
        action_id bigint not null,
        hall_id bigint not null,
        date timestamp not null,
        --
        constraint sess_pk primary key (id)
    )
    without oids ;


    create table if not exists bt.tickets(
        id bigint default nextval('bt.tick_seq'::regclass),
        seat_id bigint not null,
        session_id bigint not null,
        user_id bigint not null,
        --
        constraint ticket_pk primary key (id),
        constraint tick_uk_01 unique (session_id, seat_id)
    )
    without oids ;


    create table if not exists bt.seats(
        id bigint default nextval('bt.seat_seq'::regclass),
        hall_id bigint not null,
        number bigint not null,
        row bigint not null,
        --
        constraint seat_pk primary key (id)
    )
    without oids ;

    begin alter table bt.halls add constraint hall_ven_fk foreign key (venue_id) references bt.venues(id); exception when duplicate_object then null; end;

    begin alter table bt.seats add constraint seat_hall_fk foreign key (hall_id) references bt.halls(id); exception when duplicate_object then null; end;

    begin alter table bt.tickets add constraint tick_seat_fk foreign key (seat_id) references bt.seats(id); exception when duplicate_object then null; end;
    begin alter table bt.tickets add constraint tick_sess_fk foreign key (session_id) references bt.sessions(id); exception when duplicate_object then null; end;
    begin alter table bt.tickets add constraint tick_user_fk foreign key (user_id) references bt.users(id); exception when duplicate_object then null; end;

    begin alter table bt.sessions add constraint sess_show_fk foreign key (show_id) references bt.shows(id); exception when duplicate_object then null; end;
    begin alter table bt.sessions add constraint sess_hall_fk foreign key (hall_id) references bt.halls(id); exception when duplicate_object then null; end;

end;
$$