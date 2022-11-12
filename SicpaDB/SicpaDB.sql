--
-- PostgreSQL database dump
--

-- Dumped from database version 9.6.19
-- Dumped by pg_dump version 12.2

-- Started on 2022-11-12 02:24:46

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

--
-- TOC entry 190 (class 1259 OID 25693)
-- Name: department; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.department (
    id integer NOT NULL,
    created_by character varying(50),
    created_date timestamp without time zone,
    modified_by character varying(50),
    modified_date timestamp without time zone,
    status boolean,
    description character varying(50),
    name character varying(50),
    phone character varying(50),
    id_enterprise integer
);


ALTER TABLE public.department OWNER TO postgres;

--
-- TOC entry 189 (class 1259 OID 25691)
-- Name: department_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.department_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.department_id_seq OWNER TO postgres;

--
-- TOC entry 2161 (class 0 OID 0)
-- Dependencies: 189
-- Name: department_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.department_id_seq OWNED BY public.department.id;


--
-- TOC entry 192 (class 1259 OID 25701)
-- Name: departmentemployee; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.departmentemployee (
    id integer NOT NULL,
    created_by character varying(50),
    created_date timestamp without time zone,
    modified_by character varying(50),
    modified_date timestamp without time zone,
    status boolean,
    id_department integer,
    id_employee integer
);


ALTER TABLE public.departmentemployee OWNER TO postgres;

--
-- TOC entry 191 (class 1259 OID 25699)
-- Name: departmentemployee_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.departmentemployee_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.departmentemployee_id_seq OWNER TO postgres;

--
-- TOC entry 2162 (class 0 OID 0)
-- Dependencies: 191
-- Name: departmentemployee_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.departmentemployee_id_seq OWNED BY public.departmentemployee.id;


--
-- TOC entry 188 (class 1259 OID 25685)
-- Name: employee; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.employee (
    id integer NOT NULL,
    created_by character varying(50),
    created_date timestamp without time zone,
    modified_by character varying(50),
    modified_date timestamp without time zone,
    status boolean,
    age integer,
    email character varying(50),
    name character varying(50),
    "position" character varying(50),
    surname character varying(50)
);


ALTER TABLE public.employee OWNER TO postgres;

--
-- TOC entry 187 (class 1259 OID 25683)
-- Name: employee_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.employee_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.employee_id_seq OWNER TO postgres;

--
-- TOC entry 2163 (class 0 OID 0)
-- Dependencies: 187
-- Name: employee_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.employee_id_seq OWNED BY public.employee.id;


--
-- TOC entry 186 (class 1259 OID 25677)
-- Name: enterprise; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.enterprise (
    id integer NOT NULL,
    created_by character varying(50),
    created_date timestamp without time zone,
    modified_by character varying(50),
    modified_date timestamp without time zone,
    status boolean,
    address character varying(50),
    name character varying(50),
    phone character varying(50)
);


ALTER TABLE public.enterprise OWNER TO postgres;

--
-- TOC entry 185 (class 1259 OID 25675)
-- Name: enterprise_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.enterprise_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.enterprise_id_seq OWNER TO postgres;

--
-- TOC entry 2164 (class 0 OID 0)
-- Dependencies: 185
-- Name: enterprise_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.enterprise_id_seq OWNED BY public.enterprise.id;


--
-- TOC entry 2021 (class 2604 OID 25696)
-- Name: department id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.department ALTER COLUMN id SET DEFAULT nextval('public.department_id_seq'::regclass);


--
-- TOC entry 2022 (class 2604 OID 25704)
-- Name: departmentemployee id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.departmentemployee ALTER COLUMN id SET DEFAULT nextval('public.departmentemployee_id_seq'::regclass);


--
-- TOC entry 2020 (class 2604 OID 25688)
-- Name: employee id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employee ALTER COLUMN id SET DEFAULT nextval('public.employee_id_seq'::regclass);


--
-- TOC entry 2019 (class 2604 OID 25680)
-- Name: enterprise id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.enterprise ALTER COLUMN id SET DEFAULT nextval('public.enterprise_id_seq'::regclass);




--
-- TOC entry 2165 (class 0 OID 0)
-- Dependencies: 189
-- Name: department_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.department_id_seq', 3, true);


--
-- TOC entry 2166 (class 0 OID 0)
-- Dependencies: 191
-- Name: departmentemployee_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.departmentemployee_id_seq', 4, true);


--
-- TOC entry 2167 (class 0 OID 0)
-- Dependencies: 187
-- Name: employee_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.employee_id_seq', 7, true);


--
-- TOC entry 2168 (class 0 OID 0)
-- Dependencies: 185
-- Name: enterprise_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.enterprise_id_seq', 6, true);


--
-- TOC entry 2028 (class 2606 OID 25698)
-- Name: department department_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.department
    ADD CONSTRAINT department_pkey PRIMARY KEY (id);


--
-- TOC entry 2030 (class 2606 OID 25706)
-- Name: departmentemployee departmentemployee_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.departmentemployee
    ADD CONSTRAINT departmentemployee_pkey PRIMARY KEY (id);


--
-- TOC entry 2026 (class 2606 OID 25690)
-- Name: employee employee_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.employee
    ADD CONSTRAINT employee_pkey PRIMARY KEY (id);


--
-- TOC entry 2024 (class 2606 OID 25708)
-- Name: enterprise enterprise_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.enterprise
    ADD CONSTRAINT enterprise_pkey PRIMARY KEY (id);


-- Completed on 2022-11-12 02:24:46

--
-- PostgreSQL database dump complete
--

