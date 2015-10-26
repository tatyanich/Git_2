package com.epam.tetiana_matiunina.java.task2.lesson2.airplane.models;


import com.epam.tetiana_matiunina.java.task2.lesson2.company.BritishAirlines;
import com.epam.tetiana_matiunina.java.task2.lesson2.company.TurkishAirlines;
import com.epam.tetiana_matiunina.java.task2.lesson2.rule.GreaterThenRule;
import com.epam.tetiana_matiunina.java.task2.lesson2.rule.LessThenRule;
import com.epam.tetiana_matiunina.java.task2.lesson2.rule.QueryBuilder;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Администратор on 20.10.2015.
 */
public class Demo {
    public static void main(String[] args) {

        BritishAirlines britishAirlines = new BritishAirlines("British airlines");
        TurkishAirlines turkishAirlines = new TurkishAirlines("Turkish airlines");

        ArrayList<Airplane> airplanesBritish = new ArrayList<Airplane>();

        airplanesBritish.add(new Boing("Boing474", 9.0, 5.0, 4));
        airplanesBritish.add(new Boing("Boing472", 6.0, 4.0, 5));
        airplanesBritish.add(new Boing("Boing174", 2.7, 9.3, 5));
        airplanesBritish.add(new IL("IL44", 6.4, 1.3, 8));
        britishAirlines.addAirplanes(airplanesBritish);

        ArrayList<Airplane> airplanesTurkish = new ArrayList<Airplane>();
        airplanesBritish.add(new Boing("Boing787", 100.0, 8.0, 77));
        airplanesBritish.add(new Boing("Boing747-8", 90.0, 88.0, 5));
        airplanesBritish.add(new Boing("Boing737", 10.7, 6.3, 5));
        airplanesBritish.add(new IL("IL90", 30.4, 10.3, 9));
        turkishAirlines.addAirplanes(airplanesBritish);

        System.out.println(britishAirlines.getName());

        double totalLiftingCapacity = britishAirlines.calculateTotalCapacity();
        System.out.println("Total lifting capacity of planes: " + totalLiftingCapacity +" ton");

        double totalRoominess = britishAirlines.calculateTotalSeatingCapacity();
        System.out.println("Total roominess: " + totalRoominess+" passenger");

        System.out.println(turkishAirlines.getName());

        double totalLiftingCapacity1 = turkishAirlines.calculateTotalCapacity();
        System.out.println("Total lifting capacity of planes: " + totalLiftingCapacity1 +" ton");

        double totalSeatingCapacity1 = turkishAirlines.calculateTotalSeatingCapacity();
        System.out.println("Total roominess: " + totalSeatingCapacity1+" passenger");


        List<Airplane> planes = britishAirlines.getAirplanes();


        List<Airplane> sortedPlanesByRule = new QueryBuilder((ArrayList<Airplane>) planes)
                .addRule(new LessThenRule("liftingCapacity", 2.6))
                .addRule(new GreaterThenRule("flightDistance", 4.0))
                .run();


        britishAirlines.sortPlaneByFlightDistance();

        for (Airplane plane : britishAirlines.getAirplanes()) {
            System.out.println("Plane name: " + plane.getName() + " roominess: " + plane.getRoominess() + " distance: " + plane.getFlightDistance() + " lifting capacity: " + plane.getLiftingCapacity());
        }

        System.out.println("s");
        for (Airplane plane : sortedPlanesByRule) {
            System.out.println("Plane name: " + plane.getName() + " roominess: " + plane.getRoominess() + " distance: " + plane.getFlightDistance() + " lifting capacity: " + plane.getLiftingCapacity());
        }

    }


}
