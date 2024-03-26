do
$$
begin
--
    create sequence if not exists show_seq start with 100;
    create sequence if not exists ven_seq start with 100;
    create sequence if not exists hall_seq start with 100;
    create sequence if not exists user_seq start with 100;
    create sequence if not exists sess_seq start with 100;
    create sequence if not exists tick_seq start with 100;
    create sequence if not exists seat_seq start with 100;
    --
    create table if not exists shows(
        id bigint default nextval('show_seq'::regclass),
        title text not null,
        genre text not null,
        director text not null,
        duration text not null,
        type varchar(6) not null ,    
        --
        constraint show_pk primary key (id),
        constraint show_invalid_type_check
            check (type in ('play', 'movie'))                                   
    )
    without oids;

    create table if not exists venues(
        id bigint default nextval('ven_seq'::regclass),
        name text not null,
        address text not null,
        type varchar(7) not null,
        city text not null,
        --
        constraint ven_pk primary key (id),
        constraint ven_type_check
        check (type in ('theatre', 'cinema'))
    )
    without oids;

    create table if not exists halls(
        id bigint default nextval('hall_seq'::regclass),
        venue_id bigint not null,
        name text not null,
        --
        constraint hall_pk primary key (id)
    )
    without oids ;

    create table if not exists users(
        id bigint default nextval('user_seq'::regclass),
        phone_number text unique not null,
        password_hash text not null,
        is_admin boolean not null default false,
        name text,
        email text,
        birthday_date date,
        refresh_token varchar(32) not null,
        refresh_token_expires_at timestamp not null
        --
        constraint user_pk primary key (id)
    )
    without oids ;

    create table if not exists sessions(
        id bigint default nextval('sess_seq'::regclass),
        show_id bigint not null,
        hall_id bigint not null,
        date timestamp not null,
        --
        constraint sess_pk primary key (id)
    )
    without oids ;


    create table if not exists tickets(
        id bigint default nextval('tick_seq'::regclass),
        seat_id bigint not null,
        session_id bigint not null,
        user_id bigint not null,
        --
        constraint ticket_pk primary key (id),
        constraint tick_uk_01 unique (session_id, seat_id)
    )
    without oids ;


    create table if not exists seats(
        id bigint default nextval('seat_seq'::regclass),
        hall_id bigint not null,
        number bigint not null,
        row bigint not null,
        --
        constraint seat_pk primary key (id)
    )
    without oids ;

    begin alter table halls add constraint hall_ven_fk foreign key (venue_id) references venues(id); exception when duplicate_object then null; end;

    begin alter table seats add constraint seat_hall_fk foreign key (hall_id) references halls(id); exception when duplicate_object then null; end;

    begin alter table tickets add constraint tick_seat_fk foreign key (seat_id) references seats(id); exception when duplicate_object then null; end;
    begin alter table tickets add constraint tick_sess_fk foreign key (session_id) references sessions(id); exception when duplicate_object then null; end;
    begin alter table tickets add constraint tick_user_fk foreign key (user_id) references users(id); exception when duplicate_object then null; end;

    begin alter table sessions add constraint sess_show_fk foreign key (show_id) references shows(id); exception when duplicate_object then null; end;
    begin alter table sessions add constraint sess_hall_fk foreign key (hall_id) references halls(id); exception when duplicate_object then null; end;

end;
$$