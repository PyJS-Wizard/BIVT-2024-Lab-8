import math

def calculate_max_angle(m, M, V0, L, g=9.81):
    """
    Calculate maximum deflection angle of a ballistic pendulum
    
    Parameters:
    m: mass of bullet (kg)
    M: mass of pendulum (kg)
    V0: initial velocity of bullet (m/s)
    L: length of pendulum (m)
    g: gravitational acceleration (m/s²)
    
    Returns:
    theta_max: maximum angle in degrees
    """
    # Convert bullet mass from grams to kg
    m = m / 1000
    
    # Step 1: Find velocity after collision using conservation of momentum
    V = (m * V0) / (m + M)
    
    # Step 2: Use conservation of energy to find max height
    # Initial energy (kinetic) = Final energy (potential)
    # 1/2(M+m)V² = (M+m)gh
    # where h = L(1-cos(θ))
    
    # Maximum angle formula:
    # θ = arccos(1 - V²/(2gL))
    
    theta_max = math.acos(1 - (V**2)/(2*g*L))
    
    # Convert to degrees
    theta_max_deg = math.degrees(theta_max)
    
    return theta_max_deg

def main():
    # Given parameters
    m = 6.0    # grams
    M = 3.0    # kg
    V0 = 250   # m/s
    L = 0.5    # m
    
    theta_max = calculate_max_angle(m, M, V0, L)
    
    print("\nBallistic Pendulum Analysis")
    print("==========================")
    print(f"Bullet mass: {m} g")
    print(f"Pendulum mass: {M} kg")
    print(f"Initial bullet velocity: {V0} m/s")
    print(f"Pendulum length: {L} m")
    print(f"\nMaximum deflection angle: {theta_max:.2f}°")

if __name__ == "__main__":
    main()