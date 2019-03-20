CREATE TABLE "Orders" (
	"Number_Order" character varying(50) NOT NULL UNIQUE,
	"Name_Order" character varying(70) NOT NULL,
	"Status_Order" character varying(50) NOT NULL,
	"QR_Order" character varying(50) NOT NULL UNIQUE,
	"id_Worker" bigint
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Workers" (
	"id_worker" serial NOT NULL,
	"Name_Worker" character varying(32) NOT NULL,
	"Surname_Worker" character varying(32) NOT NULL,
	"Surname2_Worker" character varying(32) NOT NULL,
	"id_Position" bigint,
	CONSTRAINT Workers_pk PRIMARY KEY ("id_worker")
) WITH (
  OIDS=FALSE
);



CREATE TABLE "Positions" (
	"id_Position" serial NOT NULL,
	"NamePosition" character varying(50) NOT NULL,
	CONSTRAINT Positions_pk PRIMARY KEY ("id_Position")
) WITH (
  OIDS=FALSE
);



ALTER TABLE "Orders" ADD CONSTRAINT "Orders_fk0" FOREIGN KEY ("id_Worker") REFERENCES "Workers"("id_worker");

ALTER TABLE "Workers" ADD CONSTRAINT "Workers_fk0" FOREIGN KEY ("id_Position") REFERENCES "Positions"("id_Position");


