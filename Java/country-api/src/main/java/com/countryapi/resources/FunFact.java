package com.countryapi.resources;

public class FunFact {
    private final int id;
    private final String fact;
    private final Country country;

    public FunFact() {
        this.id = 0;
        this.fact = "";
        this.country = null;
    }
    public FunFact(int id, String fact, Country country) {
        this.id = id;
        this.fact = fact;
        this.country = country;
    }
    public FunFact(FunFact funFact) {
        this.id = funFact.id;
        this.fact = funFact.fact;
        this.country = funFact.country;
    }

    private int getId(){
        return id;
    }
    private String getFact(){
        return fact;
    }
    private Country getCountry(){
        return country;
    }
}
