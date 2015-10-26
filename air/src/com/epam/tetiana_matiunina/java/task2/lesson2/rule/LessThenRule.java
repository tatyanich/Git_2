package com.epam.tetiana_matiunina.java.task2.lesson2.rule;

import com.epam.tetiana_matiunina.java.task2.lesson2.airplane.models.Airplane;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;

/**
 * Created by Администратор on 22.10.2015.
 */
public class LessThenRule implements IRule {
    protected String method;

    protected double number;

    public LessThenRule(String field, double number) {
        this.method = "get" + this.capitalize(field);
        this.number = number;
    }

    /**
     * TODO move get method value to abstract class -> getValue method. Move lines 25-28 34-45 lines 29-33 = code of your compareTo method
     *
     * @param plane
     * @return
     * @throws InvocationTargetException
     * @throws IllegalAccessException
     */
    public boolean compareBy(Airplane plane) throws InvocationTargetException, IllegalAccessException {
        Object dynamicObject = null;
        try {
            Method dynamicMethod = plane.getClass().getMethod(this.method);
            dynamicObject = dynamicMethod.invoke(plane);

            if ((Double) dynamicObject < this.number) {
                return true;
            }

        } catch (NoSuchMethodException e) {

            e.printStackTrace();
        } catch (IllegalAccessException e) {
            e.printStackTrace();
        } catch (IllegalArgumentException e) {
            e.printStackTrace();
        } catch (InvocationTargetException e) {
            e.printStackTrace();
        }
        return false;
    }

    private String capitalize(final String line) {
        return Character.toUpperCase(line.charAt(0)) + line.substring(1);
    }
}
