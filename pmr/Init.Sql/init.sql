CREATE TABLE heads
(
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	first_name character varying(20) NOT NULL,
	last_name character varying(20) NOT NULL,
	middle_name character varying(20) NOT NULL,
	birth_day date NOT NULL,
	phone_number character varying(13) NOT NULL,
	phone_number_confirmed boolean NOT NULL,
	is_male boolean NOT NULL DEFAULT true,
	image_path text NOT NULL,
	region text NOT NULL,
	password_hash text NOT NULL,
	salt text NOT NULL,
	created_at timestamp without time zone NOT NULL,
	updated_at timestamp without time zone NOT NULL
);

CREATE TABLE users
(
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	first_name character varying(20) NOT NULL,
	last_name character varying(20) NOT NULL,
	middle_name character varying(20) NOT NULL,
	birth_day date NOT NULL,
	phone_number character varying(13) NOT NULL,
	phone_number_confirmed boolean NOT NULL,
	is_male boolean NOT NULL DEFAULT true,
	image_path text NOT NULL,
	region text NOT NULL,
	password_hash text NOT NULL,
	salt text NOT NULL,
	created_at timestamp without time zone NOT NULL,
	updated_at timestamp without time zone NOT NULL
);


CREATE TABLE administrators
(
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	first_name character varying(20) NOT NULL,
	last_name character varying(20) NOT NULL,
	middle_name character varying(20) NOT NULL,
	birth_day date NOT NULL,
	phone_number character varying(13) NOT NULL,
	phone_number_confirmed boolean NOT NULL,
	is_male boolean NOT NULL DEFAULT true,
	image_path text NOT NULL,
	region text NOT NULL,
	password_hash text NOT NULL,
	salt text NOT NULL,
	created_at timestamp without time zone NOT NULL,
	updated_at timestamp without time zone NOT NULL
);

CREATE TABLE doctors
(
    	id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	first_name character varying(20) NOT NULL,
	last_name character varying(20) NOT NULL,
	middle_name character varying(20) NOT NULL,
	birth_day date NOT NULL,prop		
	phone_number character varying(13) NOT NULL,
	degree text NOT NULL,
	is_male boolean NOT NULL DEFAULT true,
	image_path text NOT NULL,
	region text NOT NULL,
	appointment_money double precision,
	password_hash text NOT NULL,
	salt text NOT NULL,
	created_at timestamp without time zone NOT NULL,
	updated_at timestamp without time zone NOT NULL
);

CREATE TABLE hospitals
(
    	id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	name character varying(50) NOT NULL,
	legal_name character varying(50) NOT NULL,
	brand_image_path text NOT NULL,
	administrator_phone_number character varying(13) NOT NULL,
	fax_phone_number character varying(13) NOT NULL,
	description text NOT NULL,
	email text NOT NULL,
	website text NOT NULL,
	license_number text NOT NULL,
	license_given_date date NOT NULL,
	legal_register_number text NOT NULL,
	legal_register_number_given_date date NOT NULL,
	created_at timestamp without time zone NOT NULL,
	updated_at timestamp without time zone NOT NULL
);

CREATE TABLE categories
(
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	image_path text NOT NULL,
	professionality text NOT NULL,
	professionality_hint text NOT NULL,
	professional text NOT NULL,
	professional_hint text NOT NULL,
	created_at timestamp without time zone NOT NULL,
	updated_at timestamp without time zone NOT NULL
);

CREATE TABLE hospital_branches
(
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	name character varying(50) NOT NULL,
	hospital_id bigint REFERENCES hospitals(id) NOT NULL,
	image_path text NOT NULL,
	region text NOT NULL,
	district text NOT NULL,
	address text NOT NULL,
	destination text NOT NULL,
	adress_latitude double precision NOT NULL,
	adress_longitude double precision NOT NULL,
	contact_phone_number character varying(13) NOT NULL,
	created_at timestamp without time zone NOT NULL,
	updated_at timestamp without time zone NOT NULL
);

CREATE TABLE hospital_branch_categories
(
	id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	hospital_branch_id bigint REFERENCES hospital_branches(id) NOT NULL,
	category_id bigint REFERENCES categories(id) NOT NULL,
	created_at timestamp without time zone NOT NULL,
	updated_at timestamp without time zone NOT NULL
);

CREATE TABLE doctor_categories
(
	id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	doctor_id bigint REFERENCES doctors(id) NOT NULL,
	category_id bigint REFERENCES categories(id) NOT NULL,
	created_at timestamp without time zone NOT NULL,
	updated_at timestamp without time zone NOT NULL
);

CREATE TABLE hospital_branch_admins
(
	id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	hospital_branch_id bigint REFERENCES hospital_branches(id) NOT NULL,
	administrator_id bigint REFERENCES administrators(id) NOT NULL,
	created_at timestamp without time zone NOT NULL,
	updated_at timestamp without time zone NOT NULL
);


CREATE TABLE hospital_branch_doctors
(
	id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	hospital_branch_id bigint REFERENCES hospital_branches(id) NOT NULL,
	doctor_id bigint REFERENCES doctors(id) NOT NULL,
	is_active boolean NOT NULL,
	registered_at timestamp without time zone NOT NULL,
	stopped_at timestamp without time zone NOT NULL,
	created_at timestamp without time zone NOT NULL,
	updated_at timestamp without time zone NOT NULL
);

CREATE TABLE hospital_schedule
(
	id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	hospital_branch_id bigint REFERENCES hospital_branches(id) NOT NULL,
	doctor_id bigint REFERENCES doctors(id) NOT NULL,
	weekday text NOT NULL,
	start_time time without time zone NOT NULL,
	end_time time without time zone NOT NULL,
	description text NOT NULL,
	created_at timestamp without time zone NOT NULL,
	updated_at timestamp without time zone NOT NULL
);

CREATE TABLE doctor_appointment
(
	id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
	user_id bigint REFERENCES users(id) NOT NULL,
	doctor_id bigint REFERENCES doctors(id) NOT NULL,
	status text NOT NULL,
	hospital_branch_id bigint REFERENCES hospital_branches(id) NOT NULL,
	register_date date NOT NULL,
	start_time time without time zone NOT NULL,
	duration_minutes integer NOT NULL,
	payment_type text NOT NULL,
	payment_provider text NOT NULL,
	is_paid boolean NOT NULL,
	description text NOT NULL,
	paid_money double precision NOT NULL,
	payment_description text NOT NULL,
	stars smallint NOT NULL,
	created_at timestamp without time zone NOT NULL,
	updated_at timestamp without time zone NOT NULL
);