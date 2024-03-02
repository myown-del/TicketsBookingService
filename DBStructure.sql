do
$$
begin
    create schema if not exists bt;
    --
    create sequence if not exists bt.act_seq start with 100;
    create sequence if not exists bt.thtr_seq start with 100;
    create sequence if not exists bt.hall_seq start with 100;
    create sequence if not exists bt.user_seq start with 100;
    create sequence if not exists bt.sess_seq start with 100;
    create sequence if not exists bt.tick_seq start with 100;
    create sequence if not exists bt.seat_seq start with 100;
    --
    create table if not exists bt.actions(
        act_id bigint default nextval('bt.act_seq'::regclass),
        act_tittle text not null,
        act_genre text not null,
        act_director text not null,
        act_duration text not null,
        act_type char(1) not null ,    
        act_hall_id bigint,
        --
        constraint act_pk primary key (act_id),
        constraint act_invalid_hall_check 
            check (
                (act_type = 'm' and act_hall_id is null)
                or (act_type = 't' and act_hall_id is not null)
            )                                         
    )
    without oids ;






    create table if not exists bt.theaters(
            thtr_id bigint default nextval('bt.thtr_seq'::regclass),
            thtr_name text not null,
            thtr_adress text not null,
            thtr_type char(1) not null ,    
            --
            constraint thtr_pk primary key (thtr_id),
            constraint thtr_type_check
                check (thtr_type in ('t', 'm'))                                         
        )
        without oids ;
    
        create table if not exists bt.halls(
                hall_id bigint default nextval('bt.hall_seq'::regclass),
                hall_thtr_id bigint not null,
                hall_number text not null,    
                --
                constraint hall_pk primary key (hall_id)                                    
            )
            without oids ;
    
    create table if not exists bt.users(
                    user_id bigint default nextval('bt.user_seq'::regclass),
                    user_login text not null,
                    user_passworsd_hach text not null,  
                    user_is_admin boolean not null,  
                    --
                    constraint user_pk primary key (user_id)                                    
                )
                without oids ;

    create table if not exists bt.sessions(
                                           sess_id bigint default nextval('bt.sess_seq'::regclass),
                                           sess_act_id bigint not null,
                                           sess_hall_id bigint not null,
                                           sess_date timestamp not null,
        --
                                           constraint sess_pk primary key (sess_id)
    )
        without oids ;


    create table if not exists bt.tickets(
                                              tick_id bigint default nextval('bt.tick_seq'::regclass),
                                              tick_seat_id bigint not null,
                                              tick_sess_id bigint not null,
                                              tick_user_id bigint not null,
        --
                                              constraint tick_pk primary key (tick_id),
                                              constraint tick_uk_01 unique (tick_sess_id, tick_seat_id)
                                    
    )
        without oids ;


    create table if not exists bt.seats(
                                             seat_id bigint default nextval('bt.seat_seq'::regclass),
                                             seat_hall_id bigint not null,
                                             seat_place bigint not null,
                                             seat_row bigint not null,
        --
                                             constraint seat_pk primary key (seat_id)

    )
        without oids ;
    
    begin alter table bt.actions add constraint act_hall_fk foreign key (act_hall_id) references bt.halls(hall_id); exception when duplicate_object then null; end;

    begin alter table bt.halls add constraint hall_thtr_fk foreign key (hall_thtr_id) references bt.theaters(thtr_id); exception when duplicate_object then null; end;

    begin alter table bt.seats add constraint seat_hall_fk foreign key (seat_hall_id) references bt.halls(hall_id); exception when duplicate_object then null; end;

    begin alter table bt.tickets add constraint tick_seat_fk foreign key (tick_seat_id) references bt.seats(seat_id); exception when duplicate_object then null; end;
    begin alter table bt.tickets add constraint tick_sess_fk foreign key (tick_sess_id) references bt.sessions(sess_id); exception when duplicate_object then null; end;
    begin alter table bt.tickets add constraint tick_user_fk foreign key (tick_user_id) references bt.users(user_id); exception when duplicate_object then null; end;

    begin alter table bt.sessions add constraint sess_act_fk foreign key (sess_act_id) references bt.actions(act_id); exception when duplicate_object then null; end;
    begin alter table bt.sessions add constraint sess_hall_fk foreign key (sess_hall_id) references bt.halls(hall_id); exception when duplicate_object then null; end;

end;
$$
