

export function calculateBonus(balance:number, amountOfDeposit:number) {
    const now = new Date();
    const hour = now.getHours();
    const bonusMultiplier = hour >= 9 && hour < 17 ? .13 : .10;
    return balance >= 5000 ? amountOfDeposit * bonusMultiplier : 0;
}