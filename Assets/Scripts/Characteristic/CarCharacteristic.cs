using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CarCharacteristic
{
    /// <summary>
    /// Set Time to get max speed
    /// </summary>
    public float Acceleration { get; set; } = 1;
    /// <summary>
    /// Max speed
    /// </summary>
    public float MaxSpeed { get; set; } = 40000f;
    /// <summary>
    /// Skidding
    /// </summary>
    public float Grip { get; set; } = 1;
    /// <summary>
    /// Rotate controll posibility
    /// </summary>
    public float Dificulty { get; set; } = 1;
}
