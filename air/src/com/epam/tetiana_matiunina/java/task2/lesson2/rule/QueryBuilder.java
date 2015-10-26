package com.epam.tetiana_matiunina.java.task2.lesson2.rule;

import com.epam.tetiana_matiunina.java.task2.lesson2.airplane.models.Airplane;

import java.lang.reflect.InvocationTargetException;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Tetiana on 21.10.2015.
 */
public class QueryBuilder {

    private List<IRule> rules = new ArrayList<IRule>();

    private ArrayList<Airplane> planes;

    public QueryBuilder(ArrayList<Airplane> planes) {
        this.planes = planes;
    }

    public QueryBuilder addRule(IRule rule) {
        rules.add(rule);
        return this;
    }

    /**
     * goes through all rules and return airplane witch match
     *
     * @return list of sorted airplane
     */
    public List<Airplane> run() {


        List<Airplane> resulted = new ArrayList<Airplane>();

        for (Airplane plane : this.planes) {

            int rulesIterator = 0;

            for (IRule rule : this.rules) {
                try {
                    if (!rule.compareBy(plane)) {
                        break;
                    }
                } catch (InvocationTargetException e) {
                    e.printStackTrace();
                } catch (IllegalAccessException e) {
                    e.printStackTrace();
                }
                ++rulesIterator;
            }

            if (rulesIterator == rules.size()) {
                resulted.add(plane);
            }
        }

        return resulted;

    }
}
