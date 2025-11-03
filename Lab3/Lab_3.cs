using System;

public class ComplexNumber : ICloneable, IEquatable<ComplexNumber>
{
    // pola prywatne
    private double re;
    private double im;

    // wlaściwości publiczne
    public double Re
    {
        get => re;
        set => re = value;
    }

    public double Im
    {
        get => im;
        set => im = value;
    }

    public ComplexNumber(double re, double im)
    {
        this.re = re;
        this.im = im;
    }

    public override string ToString()
    {
        string znak = im >= 0 ? " + " : " - ";
        return $"{re}{znak}{Math.Abs(im)}i";
    }

    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.re + b.re, a.im + b.im);
    }

    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.re - b.re, a.im - b.im);
    }

    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
    {
        double real = a.re * b.re - a.im * b.im;
        double imag = a.re * b.im + a.im * b.re;
        return new ComplexNumber(real, imag);
    }

    public static ComplexNumber operator -(ComplexNumber a)
    {
        return new ComplexNumber(a.re, -a.im);
    }

    public object Clone()
    {
        return new ComplexNumber(this.re, this.im);
    }

    public bool Equals(ComplexNumber other)
    {
        if (other is null)
            return false;

        return this.re == other.re && this.im == other.im;
    }

    public override bool Equals(object obj)
    {
        if (obj is ComplexNumber other)
            return Equals(other);
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(re, im);
    }

    public static bool operator ==(ComplexNumber a, ComplexNumber b)
    {
        if (ReferenceEquals(a, b))
            return true;
        if (a is null || b is null)
            return false;
        return a.Equals(b);
    }

    public static bool operator !=(ComplexNumber a, ComplexNumber b)
    {
        return !(a == b);
    }
}

