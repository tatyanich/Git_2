package com.epam.tetiana_matiunina.java.lesson2.task2;

import com.epam.tetiana_matiunina.java.lesson2.task2.operation.MathOperationsEnum;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashMap;
import java.util.List;

/**
 * Created by Tetiana_Matiunina on 26.10.2015.
 */
public class Validator {
    public static String validate(String[] args) {

        List<String> validator = new ArrayList<>();

        MathOperationsEnum[] operations = MathOperationsEnum.values();
        String operatorsCheck = operations[0].toString()+operations[1].toString()+operations[2].toString()+operations[3].toString();
               if (args.length < 3) {
            return "Invalid mathematical expression. It must be number operand number.Possible operands: "+operatorsCheck;
        }

        if (args.length > 3) {

                return "Invalid mathematical expression. Can calculate only two numbers";

        }

        return "";
    }
}
