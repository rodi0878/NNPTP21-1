﻿using System;
using System.Collections.Generic;
using System.Drawing;
using INPTPZ1.Mathematics;

namespace INPTPZ1 {

    class NewtonFractal {
        private static readonly int MAX_NUMBER_OF_ITERATION = 30;
        private static readonly double ACCURACY_OF_ROOT=0.5;
        private static readonly double NUMBER_NEAR_TO_ZERO= 0.0001;
        private static readonly double ACCURACY_FOR_ROOT_COMPARISON = 0.01;

        private Point minPoint;
        private Point stepPoint;
        private Point maxPoint;

        private Image image;
        private Polynomial polynom;
        private Polynomial derivatedPolynom;
        private List<ComplexNumber> roots;

        public NewtonFractal(Point minPoint, Point maxPoint,ref Image image) {
            this.minPoint = minPoint;
            this.maxPoint = maxPoint;
         
            this.image = image;
            roots = new List<ComplexNumber>();
            stepPoint = new Point();
            stepPoint.x = (maxPoint.x - minPoint.x) / image.width;
            stepPoint.y = (maxPoint.y - minPoint.y) / image.height;

            polynom = new Polynomial();
            roots = new List<ComplexNumber>();
        }
 
        public void RenderNewtonFractal() {
            for (int i = 0; i < image.width; i++) {
                for (int j = 0; j < image.height; j++) {
                    ComplexNumber coordinatesOfPixel = FindCoordinatesOfPixel(j,i);
                    HandleZeroValueOfCoordinates(ref coordinatesOfPixel);
                     FindSolution(ref coordinatesOfPixel);
                    int indexOfRoot = FindRootIndex(coordinatesOfPixel);
                    image.ColorizePixel(indexOfRoot, j, i);
                }
            }
          //  image.saveImage();
                }
      public ComplexNumber  FindCoordinatesOfPixel(int xCoordinateOfPixel, int yCoordinateOfPixel) {
            double y = this.minPoint.y + yCoordinateOfPixel * stepPoint.y;
            double x = this.minPoint.x + xCoordinateOfPixel * stepPoint.x;
            return new ComplexNumber(x, y);
        }
       public void HandleZeroValueOfCoordinates(ref ComplexNumber coordinatesOfPixel) {
            if (coordinatesOfPixel.Re == 0)
                coordinatesOfPixel.Re = NUMBER_NEAR_TO_ZERO;
            if (coordinatesOfPixel.Im == 0)
                coordinatesOfPixel.Im = NUMBER_NEAR_TO_ZERO;
        }
        public ComplexNumber FindSolution(ref ComplexNumber root) {
            for (int i = 0; i < MAX_NUMBER_OF_ITERATION; i++) {
                var difference = polynom.Evaluate(root).Divide(derivatedPolynom.Evaluate(root));
                root = root.Subtract(difference);

                if (Math.Pow(difference.Re, 2) + Math.Pow(difference.Im, 2) >= ACCURACY_OF_ROOT) {
                    i--;
                }
            }
            return root;
        }
       public int FindRootIndex(ComplexNumber root) {
            var known = false;
            var indexOfRoot = 0;
            for (int i = 0; i < roots.Count; i++) {
                if (Math.Pow(root.Re - roots[i].Re, 2) + Math.Pow(root.Im - roots[i].Im, 2) <= ACCURACY_FOR_ROOT_COMPARISON) {
                    known = true;
                    indexOfRoot = i;
                }
            }
            if (!known) {
                roots.Add(root);
                indexOfRoot = roots.Count;
            }
            return indexOfRoot;
        }
       public void setPolynomial() {
            polynom.Add(new ComplexNumber(1, 0));
            polynom.Add(ComplexNumber.Zero);
            polynom.Add(ComplexNumber.Zero);
            polynom.Add(new ComplexNumber(1, 0));
            derivatedPolynom = polynom.Derive();
        }
    }
}
