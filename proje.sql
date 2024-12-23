--
-- PostgreSQL database dump
--

-- Dumped from database version 15.8
-- Dumped by pg_dump version 16.4

-- Started on 2024-12-23 19:48:07

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

--
-- TOC entry 261 (class 1255 OID 24964)
-- Name: abone_sil_trigger_fonksiyonu(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.abone_sil_trigger_fonksiyonu() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    
    DELETE FROM abonelikbilgileri
    WHERE kisiid = OLD.kisiid;

    
    DELETE FROM odemebilgileri
    WHERE kisiid = OLD.kisiid;

    RETURN OLD;
END;
$$;


ALTER FUNCTION public.abone_sil_trigger_fonksiyonu() OWNER TO postgres;

--
-- TOC entry 263 (class 1255 OID 24943)
-- Name: kategoriye_gore_ekle(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.kategoriye_gore_ekle() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    IF NEW.kategori = 'abone' THEN
        INSERT INTO abonelikbilgileri (abonelikid,kisiid,sure)
        VALUES (default,new.kisiid,null);
		
    ELSIF NEW.kategori = 'eğitmen' THEN
        INSERT INTO egitmenbilgileri (egitmenid,kisiid,uzmanlikalani)
        VALUES (default,New.kisiid,null);
	ELSIF NEW.kategori = 'ziyaretçi' THEN 
		INSERT INTO ziyaretkayitlari (ziyaretid,kisiid,giristarihi)
		VALUES (default,new.kisiid,null);
    END IF;

    RETURN NEW;
END;
$$;


ALTER FUNCTION public.kategoriye_gore_ekle() OWNER TO postgres;

--
-- TOC entry 245 (class 1255 OID 24958)
-- Name: katilimci_sayisini_guncelle(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.katilimci_sayisini_guncelle(p_etkinlikid integer) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Etkinlik için toplam katılımcı sayısını hesapla
    UPDATE etkinlikbilgileri
    SET katilimcisayisi = (
        SELECT COUNT(*)
        FROM etkinlikkatilimcilari
        WHERE etkinlikid =p_etkinlikid
    )
    WHERE etkinlikid = p_etkinlikid;
END;
$$;


ALTER FUNCTION public.katilimci_sayisini_guncelle(p_etkinlikid integer) OWNER TO postgres;

--
-- TOC entry 260 (class 1255 OID 24961)
-- Name: kontenjan_kontrol(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.kontenjan_kontrol() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
DECLARE
    mevcut_kontenjan INTEGER;
    salonun_kontenjani INTEGER;
BEGIN
    
    SELECT COUNT(*) INTO mevcut_kontenjan
    FROM etkinlikbilgileri
    WHERE salonid = NEW.salonid;

    
    SELECT kapasite INTO salonun_kontenjani
    FROM salonbilgileri
    WHERE salonid = NEW.salonid;

    
    IF mevcut_kontenjan >= salonun_kontenjani THEN
        RAISE EXCEPTION 'hata';
    END IF;

    RETURN NEW;
END;
$$;


ALTER FUNCTION public.kontenjan_kontrol() OWNER TO postgres;

--
-- TOC entry 262 (class 1255 OID 24966)
-- Name: odeme_tutarini_guncelle(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.odeme_tutarini_guncelle() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE odemebilgileri
    SET tutar = NEW.sure * 1000.00 
    WHERE kisiid = NEW.kisiid;

    RETURN NEW;
END;
$$;


ALTER FUNCTION public.odeme_tutarini_guncelle() OWNER TO postgres;

--
-- TOC entry 248 (class 1255 OID 24959)
-- Name: tetikleyici_katilimci_sayisini_guncelle(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.tetikleyici_katilimci_sayisini_guncelle() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    
    PERFORM katilimci_sayisini_guncelle(NEW.etkinlikid);

    RETURN NEW;
END;
$$;


ALTER FUNCTION public.tetikleyici_katilimci_sayisini_guncelle() OWNER TO postgres;

--
-- TOC entry 247 (class 1255 OID 24968)
-- Name: toplam_ekipman_miktari(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.toplam_ekipman_miktari() RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    toplam_miktar INTEGER;
BEGIN
    -- Tüm ekipmanların miktarlarını toplar
    SELECT SUM(miktar) INTO toplam_miktar
    FROM ekipmanbilgileri;

    -- Eğer tablo boşsa, toplam miktar 0 döner
    RETURN COALESCE(toplam_miktar, 0);
END;
$$;


ALTER FUNCTION public.toplam_ekipman_miktari() OWNER TO postgres;

--
-- TOC entry 246 (class 1255 OID 24950)
-- Name: toplam_kisi_sayisi(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.toplam_kisi_sayisi() RETURNS integer
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN (SELECT COUNT(*) FROM kisibilgileri);
END;
$$;


ALTER FUNCTION public.toplam_kisi_sayisi() OWNER TO postgres;

--
-- TOC entry 244 (class 1255 OID 24833)
-- Name: ucret(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.ucret(sure integer) RETURNS integer
    LANGUAGE plpgsql
    AS $$
begin
sure:=sure*1000;
return sure;
end;
$$;


ALTER FUNCTION public.ucret(sure integer) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 217 (class 1259 OID 24625)
-- Name: abonelikbilgileri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.abonelikbilgileri (
    abonelikid integer NOT NULL,
    kisiid integer,
    sure integer
);


ALTER TABLE public.abonelikbilgileri OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 24624)
-- Name: abonelikbilgileri_abonelikid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.abonelikbilgileri_abonelikid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    MINVALUE 0
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.abonelikbilgileri_abonelikid_seq OWNER TO postgres;

--
-- TOC entry 3499 (class 0 OID 0)
-- Dependencies: 216
-- Name: abonelikbilgileri_abonelikid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.abonelikbilgileri_abonelikid_seq OWNED BY public.abonelikbilgileri.abonelikid;


--
-- TOC entry 237 (class 1259 OID 24761)
-- Name: beslenmeprogramlari; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.beslenmeprogramlari (
    programid integer NOT NULL,
    uyeid integer,
    egitmenid integer,
    detaylar text
);


ALTER TABLE public.beslenmeprogramlari OWNER TO postgres;

--
-- TOC entry 236 (class 1259 OID 24760)
-- Name: beslenmeprogramlari_programid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.beslenmeprogramlari_programid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.beslenmeprogramlari_programid_seq OWNER TO postgres;

--
-- TOC entry 3500 (class 0 OID 0)
-- Dependencies: 236
-- Name: beslenmeprogramlari_programid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.beslenmeprogramlari_programid_seq OWNED BY public.beslenmeprogramlari.programid;


--
-- TOC entry 223 (class 1259 OID 24663)
-- Name: bireyselantrenmanbilgileri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.bireyselantrenmanbilgileri (
    antrenmanid integer NOT NULL,
    uyeid integer,
    egitmenid integer,
    tarih date,
    saat time without time zone
);


ALTER TABLE public.bireyselantrenmanbilgileri OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 24662)
-- Name: bireyselantrenmanbilgileri_antrenmanid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.bireyselantrenmanbilgileri_antrenmanid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.bireyselantrenmanbilgileri_antrenmanid_seq OWNER TO postgres;

--
-- TOC entry 3501 (class 0 OID 0)
-- Dependencies: 222
-- Name: bireyselantrenmanbilgileri_antrenmanid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.bireyselantrenmanbilgileri_antrenmanid_seq OWNED BY public.bireyselantrenmanbilgileri.antrenmanid;


--
-- TOC entry 219 (class 1259 OID 24639)
-- Name: egitmenbilgileri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.egitmenbilgileri (
    egitmenid integer NOT NULL,
    kisiid integer NOT NULL,
    uzmanlikalani character varying(50)
);


ALTER TABLE public.egitmenbilgileri OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 24638)
-- Name: egitmenbilgileri_egitmenid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.egitmenbilgileri_egitmenid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    MINVALUE 0
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.egitmenbilgileri_egitmenid_seq OWNER TO postgres;

--
-- TOC entry 3502 (class 0 OID 0)
-- Dependencies: 218
-- Name: egitmenbilgileri_egitmenid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.egitmenbilgileri_egitmenid_seq OWNED BY public.egitmenbilgileri.egitmenid;


--
-- TOC entry 227 (class 1259 OID 24689)
-- Name: ekipmanbilgileri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ekipmanbilgileri (
    ekipmanid integer NOT NULL,
    ekipmanadi character varying(50),
    miktar integer
);


ALTER TABLE public.ekipmanbilgileri OWNER TO postgres;

--
-- TOC entry 226 (class 1259 OID 24688)
-- Name: ekipmanbilgileri_ekipmanid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ekipmanbilgileri_ekipmanid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.ekipmanbilgileri_ekipmanid_seq OWNER TO postgres;

--
-- TOC entry 3503 (class 0 OID 0)
-- Dependencies: 226
-- Name: ekipmanbilgileri_ekipmanid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ekipmanbilgileri_ekipmanid_seq OWNED BY public.ekipmanbilgileri.ekipmanid;


--
-- TOC entry 229 (class 1259 OID 24696)
-- Name: ekipmankullanimkayitlari; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ekipmankullanimkayitlari (
    kullanimid integer NOT NULL,
    ekipmanid integer NOT NULL,
    kisiid integer,
    tarih date
);


ALTER TABLE public.ekipmankullanimkayitlari OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 24695)
-- Name: ekipmankullanimkayitlari_kullanimid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ekipmankullanimkayitlari_kullanimid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.ekipmankullanimkayitlari_kullanimid_seq OWNER TO postgres;

--
-- TOC entry 3504 (class 0 OID 0)
-- Dependencies: 228
-- Name: ekipmankullanimkayitlari_kullanimid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ekipmankullanimkayitlari_kullanimid_seq OWNED BY public.ekipmankullanimkayitlari.kullanimid;


--
-- TOC entry 231 (class 1259 OID 24713)
-- Name: etkinlikbilgileri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.etkinlikbilgileri (
    etkinlikid integer NOT NULL,
    etkinlikadi character varying(50),
    tarih date,
    saat time without time zone,
    salonid integer,
    katilimcisayisi integer DEFAULT 0
);


ALTER TABLE public.etkinlikbilgileri OWNER TO postgres;

--
-- TOC entry 230 (class 1259 OID 24712)
-- Name: etkinlikbilgileri_etkinlikid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.etkinlikbilgileri_etkinlikid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.etkinlikbilgileri_etkinlikid_seq OWNER TO postgres;

--
-- TOC entry 3505 (class 0 OID 0)
-- Dependencies: 230
-- Name: etkinlikbilgileri_etkinlikid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.etkinlikbilgileri_etkinlikid_seq OWNED BY public.etkinlikbilgileri.etkinlikid;


--
-- TOC entry 233 (class 1259 OID 24725)
-- Name: etkinlikkatilimcilari; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.etkinlikkatilimcilari (
    katilimciid integer NOT NULL,
    etkinlikid integer,
    kisiid integer
);


ALTER TABLE public.etkinlikkatilimcilari OWNER TO postgres;

--
-- TOC entry 232 (class 1259 OID 24724)
-- Name: etkinlikkatilimcilari_katilimciid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.etkinlikkatilimcilari_katilimciid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.etkinlikkatilimcilari_katilimciid_seq OWNER TO postgres;

--
-- TOC entry 3506 (class 0 OID 0)
-- Dependencies: 232
-- Name: etkinlikkatilimcilari_katilimciid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.etkinlikkatilimcilari_katilimciid_seq OWNED BY public.etkinlikkatilimcilari.katilimciid;


--
-- TOC entry 221 (class 1259 OID 24651)
-- Name: grupdersibilgileri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.grupdersibilgileri (
    grupdersiid integer NOT NULL,
    dersadi character varying(50),
    egitmenid integer,
    tarih date,
    saat time without time zone
);


ALTER TABLE public.grupdersibilgileri OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 24650)
-- Name: grupdersibilgileri_grupdersiid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.grupdersibilgileri_grupdersiid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.grupdersibilgileri_grupdersiid_seq OWNER TO postgres;

--
-- TOC entry 3507 (class 0 OID 0)
-- Dependencies: 220
-- Name: grupdersibilgileri_grupdersiid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.grupdersibilgileri_grupdersiid_seq OWNED BY public.grupdersibilgileri.grupdersiid;


--
-- TOC entry 215 (class 1259 OID 24616)
-- Name: kisibilgileri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.kisibilgileri (
    kisiid integer NOT NULL,
    ad character varying(50) NOT NULL,
    soyad character varying(50) NOT NULL,
    eposta character varying(50),
    telefon character varying(15) NOT NULL,
    adres text,
    dogumtarihi date,
    kategori character varying(50) NOT NULL
);


ALTER TABLE public.kisibilgileri OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 24615)
-- Name: kisibilgileri_kisiid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.kisibilgileri_kisiid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.kisibilgileri_kisiid_seq OWNER TO postgres;

--
-- TOC entry 3508 (class 0 OID 0)
-- Dependencies: 214
-- Name: kisibilgileri_kisiid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.kisibilgileri_kisiid_seq OWNED BY public.kisibilgileri.kisiid;


--
-- TOC entry 235 (class 1259 OID 24742)
-- Name: odemebilgileri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.odemebilgileri (
    odemeid integer NOT NULL,
    kisiid integer,
    tutar numeric
);


ALTER TABLE public.odemebilgileri OWNER TO postgres;

--
-- TOC entry 234 (class 1259 OID 24741)
-- Name: odemebilgileri_odemeid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.odemebilgileri_odemeid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.odemebilgileri_odemeid_seq OWNER TO postgres;

--
-- TOC entry 3509 (class 0 OID 0)
-- Dependencies: 234
-- Name: odemebilgileri_odemeid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.odemebilgileri_odemeid_seq OWNED BY public.odemebilgileri.odemeid;


--
-- TOC entry 243 (class 1259 OID 24806)
-- Name: saglikdurumubilgileri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.saglikdurumubilgileri (
    saglikdurumuid integer NOT NULL,
    kisiid integer,
    saglikdurumu text,
    tarih date
);


ALTER TABLE public.saglikdurumubilgileri OWNER TO postgres;

--
-- TOC entry 242 (class 1259 OID 24805)
-- Name: saglikdurumubilgileri_saglikdurumuid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.saglikdurumubilgileri_saglikdurumuid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.saglikdurumubilgileri_saglikdurumuid_seq OWNER TO postgres;

--
-- TOC entry 3510 (class 0 OID 0)
-- Dependencies: 242
-- Name: saglikdurumubilgileri_saglikdurumuid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.saglikdurumubilgileri_saglikdurumuid_seq OWNED BY public.saglikdurumubilgileri.saglikdurumuid;


--
-- TOC entry 225 (class 1259 OID 24680)
-- Name: salonbilgileri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.salonbilgileri (
    salonid integer NOT NULL,
    salonadi character varying(50),
    kapasite integer
);


ALTER TABLE public.salonbilgileri OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 24679)
-- Name: salonbilgileri_salonid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.salonbilgileri_salonid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.salonbilgileri_salonid_seq OWNER TO postgres;

--
-- TOC entry 3511 (class 0 OID 0)
-- Dependencies: 224
-- Name: salonbilgileri_salonid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.salonbilgileri_salonid_seq OWNED BY public.salonbilgileri.salonid;


--
-- TOC entry 241 (class 1259 OID 24792)
-- Name: sikayetveoneriler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sikayetveoneriler (
    sikayetid integer NOT NULL,
    kisiid integer,
    konu character varying(100),
    aciklama text,
    tarih date,
    durum character varying(50)
);


ALTER TABLE public.sikayetveoneriler OWNER TO postgres;

--
-- TOC entry 240 (class 1259 OID 24791)
-- Name: sikayetveoneriler_sikayetid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sikayetveoneriler_sikayetid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.sikayetveoneriler_sikayetid_seq OWNER TO postgres;

--
-- TOC entry 3512 (class 0 OID 0)
-- Dependencies: 240
-- Name: sikayetveoneriler_sikayetid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.sikayetveoneriler_sikayetid_seq OWNED BY public.sikayetveoneriler.sikayetid;


--
-- TOC entry 239 (class 1259 OID 24780)
-- Name: ziyaretkayitlari; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ziyaretkayitlari (
    ziyaretid integer NOT NULL,
    kisiid integer,
    giristarihi timestamp without time zone
);


ALTER TABLE public.ziyaretkayitlari OWNER TO postgres;

--
-- TOC entry 238 (class 1259 OID 24779)
-- Name: ziyaretkayitlari_ziyaretid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ziyaretkayitlari_ziyaretid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.ziyaretkayitlari_ziyaretid_seq OWNER TO postgres;

--
-- TOC entry 3513 (class 0 OID 0)
-- Dependencies: 238
-- Name: ziyaretkayitlari_ziyaretid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ziyaretkayitlari_ziyaretid_seq OWNED BY public.ziyaretkayitlari.ziyaretid;


--
-- TOC entry 3253 (class 2604 OID 24628)
-- Name: abonelikbilgileri abonelikid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.abonelikbilgileri ALTER COLUMN abonelikid SET DEFAULT nextval('public.abonelikbilgileri_abonelikid_seq'::regclass);


--
-- TOC entry 3264 (class 2604 OID 24764)
-- Name: beslenmeprogramlari programid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.beslenmeprogramlari ALTER COLUMN programid SET DEFAULT nextval('public.beslenmeprogramlari_programid_seq'::regclass);


--
-- TOC entry 3256 (class 2604 OID 24666)
-- Name: bireyselantrenmanbilgileri antrenmanid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bireyselantrenmanbilgileri ALTER COLUMN antrenmanid SET DEFAULT nextval('public.bireyselantrenmanbilgileri_antrenmanid_seq'::regclass);


--
-- TOC entry 3254 (class 2604 OID 24642)
-- Name: egitmenbilgileri egitmenid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.egitmenbilgileri ALTER COLUMN egitmenid SET DEFAULT nextval('public.egitmenbilgileri_egitmenid_seq'::regclass);


--
-- TOC entry 3258 (class 2604 OID 24692)
-- Name: ekipmanbilgileri ekipmanid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ekipmanbilgileri ALTER COLUMN ekipmanid SET DEFAULT nextval('public.ekipmanbilgileri_ekipmanid_seq'::regclass);


--
-- TOC entry 3259 (class 2604 OID 24699)
-- Name: ekipmankullanimkayitlari kullanimid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ekipmankullanimkayitlari ALTER COLUMN kullanimid SET DEFAULT nextval('public.ekipmankullanimkayitlari_kullanimid_seq'::regclass);


--
-- TOC entry 3260 (class 2604 OID 24716)
-- Name: etkinlikbilgileri etkinlikid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.etkinlikbilgileri ALTER COLUMN etkinlikid SET DEFAULT nextval('public.etkinlikbilgileri_etkinlikid_seq'::regclass);


--
-- TOC entry 3262 (class 2604 OID 24728)
-- Name: etkinlikkatilimcilari katilimciid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.etkinlikkatilimcilari ALTER COLUMN katilimciid SET DEFAULT nextval('public.etkinlikkatilimcilari_katilimciid_seq'::regclass);


--
-- TOC entry 3255 (class 2604 OID 24654)
-- Name: grupdersibilgileri grupdersiid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.grupdersibilgileri ALTER COLUMN grupdersiid SET DEFAULT nextval('public.grupdersibilgileri_grupdersiid_seq'::regclass);


--
-- TOC entry 3252 (class 2604 OID 24619)
-- Name: kisibilgileri kisiid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kisibilgileri ALTER COLUMN kisiid SET DEFAULT nextval('public.kisibilgileri_kisiid_seq'::regclass);


--
-- TOC entry 3263 (class 2604 OID 24745)
-- Name: odemebilgileri odemeid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.odemebilgileri ALTER COLUMN odemeid SET DEFAULT nextval('public.odemebilgileri_odemeid_seq'::regclass);


--
-- TOC entry 3267 (class 2604 OID 24809)
-- Name: saglikdurumubilgileri saglikdurumuid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.saglikdurumubilgileri ALTER COLUMN saglikdurumuid SET DEFAULT nextval('public.saglikdurumubilgileri_saglikdurumuid_seq'::regclass);


--
-- TOC entry 3257 (class 2604 OID 24683)
-- Name: salonbilgileri salonid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.salonbilgileri ALTER COLUMN salonid SET DEFAULT nextval('public.salonbilgileri_salonid_seq'::regclass);


--
-- TOC entry 3266 (class 2604 OID 24795)
-- Name: sikayetveoneriler sikayetid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sikayetveoneriler ALTER COLUMN sikayetid SET DEFAULT nextval('public.sikayetveoneriler_sikayetid_seq'::regclass);


--
-- TOC entry 3265 (class 2604 OID 24783)
-- Name: ziyaretkayitlari ziyaretid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ziyaretkayitlari ALTER COLUMN ziyaretid SET DEFAULT nextval('public.ziyaretkayitlari_ziyaretid_seq'::regclass);


--
-- TOC entry 3467 (class 0 OID 24625)
-- Dependencies: 217
-- Data for Name: abonelikbilgileri; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.abonelikbilgileri (abonelikid, kisiid, sure) FROM stdin;
1	2	3
2	6	4
3	7	6
4	9	13
6	13	5
8	16	3
9	17	7
10	18	8
11	20	2
12	23	9
13	24	12
14	26	10
7	14	3
\.


--
-- TOC entry 3487 (class 0 OID 24761)
-- Dependencies: 237
-- Data for Name: beslenmeprogramlari; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.beslenmeprogramlari (programid, uyeid, egitmenid, detaylar) FROM stdin;
1	2	4	diyet beslenme programı hazırlandı
2	7	5	normal beslenme programı hazırlandı
3	2	6	normal beslenme programı hazırlandı
\.


--
-- TOC entry 3473 (class 0 OID 24663)
-- Dependencies: 223
-- Data for Name: bireyselantrenmanbilgileri; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.bireyselantrenmanbilgileri (antrenmanid, uyeid, egitmenid, tarih, saat) FROM stdin;
2	12	8	2024-08-25	12:00:00
1	4	9	2024-05-10	15:30:00
\.


--
-- TOC entry 3469 (class 0 OID 24639)
-- Dependencies: 219
-- Data for Name: egitmenbilgileri; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.egitmenbilgileri (egitmenid, kisiid, uzmanlikalani) FROM stdin;
1	3	fitness
2	4	fitness
3	5	fitness
4	8	fitness
5	11	fitness
6	12	fitness
7	15	fitness
8	19	fitness
9	21	fitness
10	25	fitness
11	27	fitness
12	28	fitness
13	33	Dövüş sporları
\.


--
-- TOC entry 3477 (class 0 OID 24689)
-- Dependencies: 227
-- Data for Name: ekipmanbilgileri; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ekipmanbilgileri (ekipmanid, ekipmanadi, miktar) FROM stdin;
1	ekipman1	15
2	ekipman2	20
3	ekipman4	13
\.


--
-- TOC entry 3479 (class 0 OID 24696)
-- Dependencies: 229
-- Data for Name: ekipmankullanimkayitlari; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ekipmankullanimkayitlari (kullanimid, ekipmanid, kisiid, tarih) FROM stdin;
2	1	14	2024-03-02
3	2	9	\N
4	2	6	\N
5	3	18	2023-10-20
7	3	14	2024-02-05
\.


--
-- TOC entry 3481 (class 0 OID 24713)
-- Dependencies: 231
-- Data for Name: etkinlikbilgileri; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.etkinlikbilgileri (etkinlikid, etkinlikadi, tarih, saat, salonid, katilimcisayisi) FROM stdin;
6	etkinlik3	2024-10-15	18:00:00	1	3
5	etkinlik2	2024-12-23	18:00:00	4	3
7	etkinlik4	2022-10-15	19:00:00	5	6
3	pilates	2023-10-16	14:00:00	1	11
4	etkinlik1	2024-11-26	12:30:00	2	1
\.


--
-- TOC entry 3483 (class 0 OID 24725)
-- Dependencies: 233
-- Data for Name: etkinlikkatilimcilari; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.etkinlikkatilimcilari (katilimciid, etkinlikid, kisiid) FROM stdin;
3	3	4
4	3	5
5	3	8
7	3	12
9	3	5
10	3	8
11	3	9
14	7	17
15	7	16
16	7	19
17	7	20
18	7	23
19	3	8
20	3	16
21	4	2
22	5	9
23	6	12
24	6	13
25	6	11
26	5	18
27	5	14
\.


--
-- TOC entry 3471 (class 0 OID 24651)
-- Dependencies: 221
-- Data for Name: grupdersibilgileri; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.grupdersibilgileri (grupdersiid, dersadi, egitmenid, tarih, saat) FROM stdin;
1	ders01	5	2022-04-05	15:00:00
2	ders02	7	2023-08-22	17:00:00
\.


--
-- TOC entry 3465 (class 0 OID 24616)
-- Dependencies: 215
-- Data for Name: kisibilgileri; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.kisibilgileri (kisiid, ad, soyad, eposta, telefon, adres, dogumtarihi, kategori) FROM stdin;
23	melike	colak	melike@ml	342-3925	papatya sokak	2004-04-14	abone
25	Banu	Yıldırım	banu.yıldırım@gmail.com	555-1257	155 manolya sokak	2004-12-04	eğitmen
4	Hadise	Acıkgöz	haadise@gmail.com	464-5645	123.sokak	1990-07-03	eğitmen
24	Elif	Yılmaz	elif.yilmaz@gmail.com	555-1234	155 manolya sokak	2004-12-04	abone
26	Ersel	Şimşek	erselsimsek@gmail.com	444-4444	kemalpaşa mah.	2004-06-05	abone
2	Ahmet	Yılmaz	ahmetyilmaz@example.com	555-1234	123 Çam Sokağı	1985-02-15	abone
3	Aylin	Demir	aylindemir@example.com	555-5678	456 Meşe Caddesi	1990-07-21	eğitmen
5	Murat	Çelik	muratcelik@example.com	555-2345	321 Akasya Sokak	1982-05-09	eğitmen
6	Zeynep	Kılıç	zeynepkilic@example.com	555-9876	654 Söğüt Sokağı	1995-08-19	abone\n
7	Mehmet	Öz	mehmetoz@example.com	555-3456	987 İğde Bulvarı	1983-03-07	abone\n
8	Aslı	Güner	asliguner@example.com	555-6543	741 Ladin Sokak	1992-09-27	eğitmen
9	Kemal	Yıldız	kemalyildiz@example.com	555-4567	852 Söğüt Caddesi	1989-10-14	abone
11	Hüseyin	Arslan	huseyinarslan@example.com	555-5678	159 Meşe Caddesi	1981-06-30	eğitmen
12	Ela	Kurt	elakurt@example.com	555-6789	753 Kiraz Sokağı	1993-04-18	eğitmen
13	Yusuf	Şahin	yusufshain@example.com	555-8765	864 Çam Sokağı	1986-01-25	abone\n
14	Elif	Aksoy	elifaksoy@example.com	555-3456	951 Meşe Caddesi	1991-07-16	abone
16	Banu	Uçar	banuucar@example.com	555-2345	369 Söğüt Sokağı	1989-11-03	abone 
17	Levent	Topçu	leventtopcu@example.com	555-6543	159 İğde Bulvarı	1992-08-05	abone
18	Sibel	Sezer	sibelsezer@example.com	555-8765	753 Ladin Sokak	1985-12-27	abone
19	Deniz	Karaca	denizkaraca@example.com	555-4567	951 Söğüt Caddesi	1987-03-14	eğitmen
20	Gizem	Şen	gizems@example.com	555-7654	159 Kavak Sokağı	1990-09-01	abone
21	Onur	Özkan	onurozkan@example.com	555-9876	357 Meşe Caddesi	1994-11-23	eğitmen
15	Tolga	Erdil	tolgaerdogan@example.com	555-5432	753 Çınar Yolu	1984-02-10	eğitmen
27	Ebru	Kaya	ebru@gmail.com	555-5555	13456.sokak	1987-06-08	eğitmen
28	Sinem	Korhan	sinem@gmail.com	555-5555	13456.sokak	1987-06-08	eğitmen
33	Yusuf 	Atılgan	ysf@gmail.com	686-8588	132464.sokak	2007-12-06	eğitmen
\.


--
-- TOC entry 3485 (class 0 OID 24742)
-- Dependencies: 235
-- Data for Name: odemebilgileri; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.odemebilgileri (odemeid, kisiid, tutar) FROM stdin;
2	14	300.00
\.


--
-- TOC entry 3493 (class 0 OID 24806)
-- Dependencies: 243
-- Data for Name: saglikdurumubilgileri; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.saglikdurumubilgileri (saglikdurumuid, kisiid, saglikdurumu, tarih) FROM stdin;
\.


--
-- TOC entry 3475 (class 0 OID 24680)
-- Dependencies: 225
-- Data for Name: salonbilgileri; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.salonbilgileri (salonid, salonadi, kapasite) FROM stdin;
1	salon2	20
2	salon5	10
3	salon4	5
4	salon3	15
5	salon1	3
\.


--
-- TOC entry 3491 (class 0 OID 24792)
-- Dependencies: 241
-- Data for Name: sikayetveoneriler; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sikayetveoneriler (sikayetid, kisiid, konu, aciklama, tarih, durum) FROM stdin;
\.


--
-- TOC entry 3489 (class 0 OID 24780)
-- Dependencies: 239
-- Data for Name: ziyaretkayitlari; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ziyaretkayitlari (ziyaretid, kisiid, giristarihi) FROM stdin;
\.


--
-- TOC entry 3514 (class 0 OID 0)
-- Dependencies: 216
-- Name: abonelikbilgileri_abonelikid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.abonelikbilgileri_abonelikid_seq', 17, true);


--
-- TOC entry 3515 (class 0 OID 0)
-- Dependencies: 236
-- Name: beslenmeprogramlari_programid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.beslenmeprogramlari_programid_seq', 4, true);


--
-- TOC entry 3516 (class 0 OID 0)
-- Dependencies: 222
-- Name: bireyselantrenmanbilgileri_antrenmanid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.bireyselantrenmanbilgileri_antrenmanid_seq', 6, true);


--
-- TOC entry 3517 (class 0 OID 0)
-- Dependencies: 218
-- Name: egitmenbilgileri_egitmenid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.egitmenbilgileri_egitmenid_seq', 13, true);


--
-- TOC entry 3518 (class 0 OID 0)
-- Dependencies: 226
-- Name: ekipmanbilgileri_ekipmanid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ekipmanbilgileri_ekipmanid_seq', 3, true);


--
-- TOC entry 3519 (class 0 OID 0)
-- Dependencies: 228
-- Name: ekipmankullanimkayitlari_kullanimid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ekipmankullanimkayitlari_kullanimid_seq', 8, true);


--
-- TOC entry 3520 (class 0 OID 0)
-- Dependencies: 230
-- Name: etkinlikbilgileri_etkinlikid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.etkinlikbilgileri_etkinlikid_seq', 7, true);


--
-- TOC entry 3521 (class 0 OID 0)
-- Dependencies: 232
-- Name: etkinlikkatilimcilari_katilimciid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.etkinlikkatilimcilari_katilimciid_seq', 27, true);


--
-- TOC entry 3522 (class 0 OID 0)
-- Dependencies: 220
-- Name: grupdersibilgileri_grupdersiid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.grupdersibilgileri_grupdersiid_seq', 2, true);


--
-- TOC entry 3523 (class 0 OID 0)
-- Dependencies: 214
-- Name: kisibilgileri_kisiid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.kisibilgileri_kisiid_seq', 35, true);


--
-- TOC entry 3524 (class 0 OID 0)
-- Dependencies: 234
-- Name: odemebilgileri_odemeid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.odemebilgileri_odemeid_seq', 2, true);


--
-- TOC entry 3525 (class 0 OID 0)
-- Dependencies: 242
-- Name: saglikdurumubilgileri_saglikdurumuid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.saglikdurumubilgileri_saglikdurumuid_seq', 1, false);


--
-- TOC entry 3526 (class 0 OID 0)
-- Dependencies: 224
-- Name: salonbilgileri_salonid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.salonbilgileri_salonid_seq', 5, true);


--
-- TOC entry 3527 (class 0 OID 0)
-- Dependencies: 240
-- Name: sikayetveoneriler_sikayetid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sikayetveoneriler_sikayetid_seq', 1, false);


--
-- TOC entry 3528 (class 0 OID 0)
-- Dependencies: 238
-- Name: ziyaretkayitlari_ziyaretid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ziyaretkayitlari_ziyaretid_seq', 1, false);


--
-- TOC entry 3271 (class 2606 OID 24632)
-- Name: abonelikbilgileri abonelikbilgileri_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.abonelikbilgileri
    ADD CONSTRAINT abonelikbilgileri_pkey PRIMARY KEY (abonelikid);


--
-- TOC entry 3294 (class 2606 OID 24768)
-- Name: beslenmeprogramlari beslenmeprogramlari_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.beslenmeprogramlari
    ADD CONSTRAINT beslenmeprogramlari_pkey PRIMARY KEY (programid);


--
-- TOC entry 3280 (class 2606 OID 24668)
-- Name: bireyselantrenmanbilgileri bireyselantrenmanbilgileri_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bireyselantrenmanbilgileri
    ADD CONSTRAINT bireyselantrenmanbilgileri_pkey PRIMARY KEY (antrenmanid);


--
-- TOC entry 3274 (class 2606 OID 24644)
-- Name: egitmenbilgileri egitmenbilgileri_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.egitmenbilgileri
    ADD CONSTRAINT egitmenbilgileri_pkey PRIMARY KEY (egitmenid);


--
-- TOC entry 3284 (class 2606 OID 24694)
-- Name: ekipmanbilgileri ekipmanbilgileri_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ekipmanbilgileri
    ADD CONSTRAINT ekipmanbilgileri_pkey PRIMARY KEY (ekipmanid);


--
-- TOC entry 3286 (class 2606 OID 24701)
-- Name: ekipmankullanimkayitlari ekipmankullanimkayitlari_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ekipmankullanimkayitlari
    ADD CONSTRAINT ekipmankullanimkayitlari_pkey PRIMARY KEY (kullanimid);


--
-- TOC entry 3288 (class 2606 OID 24718)
-- Name: etkinlikbilgileri etkinlikbilgileri_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.etkinlikbilgileri
    ADD CONSTRAINT etkinlikbilgileri_pkey PRIMARY KEY (etkinlikid);


--
-- TOC entry 3290 (class 2606 OID 24730)
-- Name: etkinlikkatilimcilari etkinlikkatilimcilari_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.etkinlikkatilimcilari
    ADD CONSTRAINT etkinlikkatilimcilari_pkey PRIMARY KEY (katilimciid);


--
-- TOC entry 3278 (class 2606 OID 24656)
-- Name: grupdersibilgileri grupdersibilgileri_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.grupdersibilgileri
    ADD CONSTRAINT grupdersibilgileri_pkey PRIMARY KEY (grupdersiid);


--
-- TOC entry 3269 (class 2606 OID 24623)
-- Name: kisibilgileri kisibilgileri_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kisibilgileri
    ADD CONSTRAINT kisibilgileri_pkey PRIMARY KEY (kisiid);


--
-- TOC entry 3292 (class 2606 OID 24749)
-- Name: odemebilgileri odemebilgileri_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.odemebilgileri
    ADD CONSTRAINT odemebilgileri_pkey PRIMARY KEY (odemeid);


--
-- TOC entry 3300 (class 2606 OID 24813)
-- Name: saglikdurumubilgileri saglikdurumubilgileri_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.saglikdurumubilgileri
    ADD CONSTRAINT saglikdurumubilgileri_pkey PRIMARY KEY (saglikdurumuid);


--
-- TOC entry 3282 (class 2606 OID 24687)
-- Name: salonbilgileri salonbilgileri_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.salonbilgileri
    ADD CONSTRAINT salonbilgileri_pkey PRIMARY KEY (salonid);


--
-- TOC entry 3298 (class 2606 OID 24799)
-- Name: sikayetveoneriler sikayetveoneriler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sikayetveoneriler
    ADD CONSTRAINT sikayetveoneriler_pkey PRIMARY KEY (sikayetid);


--
-- TOC entry 3296 (class 2606 OID 24785)
-- Name: ziyaretkayitlari ziyaretkayitlari_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ziyaretkayitlari
    ADD CONSTRAINT ziyaretkayitlari_pkey PRIMARY KEY (ziyaretid);


--
-- TOC entry 3272 (class 1259 OID 24851)
-- Name: fki_abonelikbilgileri_kisiid_fkey; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_abonelikbilgileri_kisiid_fkey ON public.abonelikbilgileri USING btree (kisiid);


--
-- TOC entry 3275 (class 1259 OID 24839)
-- Name: fki_egitmenbilgileri_fkey; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_egitmenbilgileri_fkey ON public.egitmenbilgileri USING btree (kisiid);


--
-- TOC entry 3276 (class 1259 OID 24845)
-- Name: fki_egitmenbilgileri_kisiid_fkey; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_egitmenbilgileri_kisiid_fkey ON public.egitmenbilgileri USING btree (kisiid);


--
-- TOC entry 3317 (class 2620 OID 24965)
-- Name: kisibilgileri abone_sil_trigger; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER abone_sil_trigger AFTER DELETE ON public.kisibilgileri FOR EACH ROW WHEN (((old.kategori)::text = 'abone'::text)) EXECUTE FUNCTION public.abone_sil_trigger_fonksiyonu();


--
-- TOC entry 3321 (class 2620 OID 24960)
-- Name: etkinlikkatilimcilari katilimci_sayisi_guncelle; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER katilimci_sayisi_guncelle AFTER INSERT OR DELETE ON public.etkinlikkatilimcilari FOR EACH ROW EXECUTE FUNCTION public.tetikleyici_katilimci_sayisini_guncelle();


--
-- TOC entry 3318 (class 2620 OID 24944)
-- Name: kisibilgileri kisi_kategori_trigger; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER kisi_kategori_trigger AFTER INSERT ON public.kisibilgileri FOR EACH ROW EXECUTE FUNCTION public.kategoriye_gore_ekle();


--
-- TOC entry 3320 (class 2620 OID 24962)
-- Name: etkinlikbilgileri kontenjan_dogrulama; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER kontenjan_dogrulama BEFORE INSERT ON public.etkinlikbilgileri FOR EACH ROW EXECUTE FUNCTION public.kontenjan_kontrol();


--
-- TOC entry 3319 (class 2620 OID 24967)
-- Name: abonelikbilgileri sure_guncelle_trigger; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER sure_guncelle_trigger AFTER UPDATE OF sure ON public.abonelikbilgileri FOR EACH ROW EXECUTE FUNCTION public.odeme_tutarini_guncelle();


--
-- TOC entry 3301 (class 2606 OID 24846)
-- Name: abonelikbilgileri abonelikbilgileri_kisiid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.abonelikbilgileri
    ADD CONSTRAINT abonelikbilgileri_kisiid_fkey FOREIGN KEY (kisiid) REFERENCES public.kisibilgileri(kisiid) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3312 (class 2606 OID 24852)
-- Name: beslenmeprogramlari beslenmeprogramlari_egitmenid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.beslenmeprogramlari
    ADD CONSTRAINT beslenmeprogramlari_egitmenid_fkey FOREIGN KEY (egitmenid) REFERENCES public.egitmenbilgileri(egitmenid) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3313 (class 2606 OID 24938)
-- Name: beslenmeprogramlari beslenmeprogramlari_uyeid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.beslenmeprogramlari
    ADD CONSTRAINT beslenmeprogramlari_uyeid_fkey FOREIGN KEY (uyeid) REFERENCES public.abonelikbilgileri(abonelikid) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3304 (class 2606 OID 24862)
-- Name: bireyselantrenmanbilgileri bireyselantrenmanbilgileri_egitmenid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bireyselantrenmanbilgileri
    ADD CONSTRAINT bireyselantrenmanbilgileri_egitmenid_fkey FOREIGN KEY (egitmenid) REFERENCES public.egitmenbilgileri(egitmenid) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3305 (class 2606 OID 24945)
-- Name: bireyselantrenmanbilgileri bireyselantrenmanbilgileri_uyeid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bireyselantrenmanbilgileri
    ADD CONSTRAINT bireyselantrenmanbilgileri_uyeid_fkey FOREIGN KEY (uyeid) REFERENCES public.abonelikbilgileri(abonelikid) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3302 (class 2606 OID 24840)
-- Name: egitmenbilgileri egitmenbilgileri_kisiid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.egitmenbilgileri
    ADD CONSTRAINT egitmenbilgileri_kisiid_fkey FOREIGN KEY (kisiid) REFERENCES public.kisibilgileri(kisiid) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3306 (class 2606 OID 24872)
-- Name: ekipmankullanimkayitlari ekipmankullanimkayitlari_ekipmanid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ekipmankullanimkayitlari
    ADD CONSTRAINT ekipmankullanimkayitlari_ekipmanid_fkey FOREIGN KEY (ekipmanid) REFERENCES public.ekipmanbilgileri(ekipmanid) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3307 (class 2606 OID 24877)
-- Name: ekipmankullanimkayitlari ekipmankullanimkayitlari_kisiid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ekipmankullanimkayitlari
    ADD CONSTRAINT ekipmankullanimkayitlari_kisiid_fkey FOREIGN KEY (kisiid) REFERENCES public.kisibilgileri(kisiid) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3308 (class 2606 OID 24882)
-- Name: etkinlikbilgileri etkinlikbilgileri_salonid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.etkinlikbilgileri
    ADD CONSTRAINT etkinlikbilgileri_salonid_fkey FOREIGN KEY (salonid) REFERENCES public.salonbilgileri(salonid) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3309 (class 2606 OID 24892)
-- Name: etkinlikkatilimcilari etkinlikkatilimcilari_etkinlikid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.etkinlikkatilimcilari
    ADD CONSTRAINT etkinlikkatilimcilari_etkinlikid_fkey FOREIGN KEY (etkinlikid) REFERENCES public.etkinlikbilgileri(etkinlikid) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3310 (class 2606 OID 24887)
-- Name: etkinlikkatilimcilari etkinlikkatilimcilari_kisiid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.etkinlikkatilimcilari
    ADD CONSTRAINT etkinlikkatilimcilari_kisiid_fkey FOREIGN KEY (kisiid) REFERENCES public.kisibilgileri(kisiid) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3303 (class 2606 OID 24897)
-- Name: grupdersibilgileri grupdersibilgileri_egitmenid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.grupdersibilgileri
    ADD CONSTRAINT grupdersibilgileri_egitmenid_fkey FOREIGN KEY (egitmenid) REFERENCES public.egitmenbilgileri(egitmenid) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3311 (class 2606 OID 24902)
-- Name: odemebilgileri odemebilgileri_kisiid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.odemebilgileri
    ADD CONSTRAINT odemebilgileri_kisiid_fkey FOREIGN KEY (kisiid) REFERENCES public.kisibilgileri(kisiid) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3316 (class 2606 OID 24912)
-- Name: saglikdurumubilgileri saglikdurumubilgileri_kisiid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.saglikdurumubilgileri
    ADD CONSTRAINT saglikdurumubilgileri_kisiid_fkey FOREIGN KEY (kisiid) REFERENCES public.kisibilgileri(kisiid) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3315 (class 2606 OID 24917)
-- Name: sikayetveoneriler sikayetveoneriler_kisiid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sikayetveoneriler
    ADD CONSTRAINT sikayetveoneriler_kisiid_fkey FOREIGN KEY (kisiid) REFERENCES public.kisibilgileri(kisiid) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3314 (class 2606 OID 24922)
-- Name: ziyaretkayitlari ziyaretkayitlari_kisiid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ziyaretkayitlari
    ADD CONSTRAINT ziyaretkayitlari_kisiid_fkey FOREIGN KEY (kisiid) REFERENCES public.kisibilgileri(kisiid) ON UPDATE CASCADE ON DELETE CASCADE;


-- Completed on 2024-12-23 19:48:07

--
-- PostgreSQL database dump complete
--

