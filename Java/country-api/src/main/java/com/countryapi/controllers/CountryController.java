package com.countryapi.controllers;

import com.countryapi.resources.Country;
import com.countryapi.resources.Greeting;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.concurrent.atomic.AtomicLong;

@RestController
public class CountryController {
    private static final String template = "Hello, %s!";
    private final AtomicLong counter = new AtomicLong();

    @GetMapping("/greet")
    public Greeting getGreeting(@RequestParam(value="name",  defaultValue = "default") String name){
        return new Greeting(counter.incrementAndGet(), String.format(template, name));
    }
}
