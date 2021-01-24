package com.countryapi.resources;

import java.util.ArrayList;

public class Country {
    private final int id;
    private final String name;
    private final String code;
    private final ArrayList<FunFact> funFacts;

    public Country(){
        this.id = 0;
        this.name = "";
        this.code = "";
        this.funFacts = new ArrayList<>();
    }
    public Country(int id, String name, String code, ArrayList<FunFact> funFacts) {
        this.id = id;
        this.name = name;
        this.code = code;
        this.funFacts = funFacts;
    }
    public Country(Country country){
        this.id = country.id;
        this.name = country.name;
        this.code = country.code;
        this.funFacts = country.funFacts;
    }

    private int getId(){
        return id;
    }
    private String getName(){
        return name;
    }
    private String getCode(){
        return code;
    }
    private ArrayList<FunFact> getFunFacts(){
        return funFacts;
    }
}
