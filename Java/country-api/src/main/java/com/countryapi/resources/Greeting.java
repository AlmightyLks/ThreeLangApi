package com.countryapi.resources;

public class Greeting {
    private final long id;
    private final String content;

    public Greeting(String content) {
        this.content = content;
        this.id = 0;
    }
    public Greeting(long id, String content) {
        this.id = id;
        this.content = content;
    }

    private long getId(){
        return id;
    }

    public String getContent() {
        return content;
    }
}
