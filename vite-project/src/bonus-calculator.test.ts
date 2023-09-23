import { describe, it, expect, beforeEach, vi, afterEach } from 'vitest';
import { calculateBonus } from './bonus-calculator';

describe('The Bonus Calculator', () => {
    beforeEach(() => {
        vi.useFakeTimers();
    });

    describe('Getting a Bonus When Account Has Sufficient Funds', () => {
        it('gives ten percent outside business hours', () => {
            const date = new Date(2023, 11, 23, 17);
            vi.setSystemTime(date);
            const bonus = calculateBonus(5000, 100);
            expect(bonus).toBe(10);
        });

        it('gives 13% after business hours', () => {
            const date = new Date(2023, 11, 23, 16);
            vi.setSystemTime(date);
            const bonus = calculateBonus(5000, 100);
            expect(bonus).toBe(13);
        });
    
    })
    describe('No Bonus Without Sufficient Funds', () => {
        it('gives ten percent outside business hours', () => {
            const date = new Date(2023, 11, 23, 17);
            vi.setSystemTime(date);
            const bonus = calculateBonus(4999.99, 100);
            expect(bonus).toBe(0);
        });

        it('gives 13% after business hours', () => {
            const date = new Date(2023, 11, 23, 16);
            vi.setSystemTime(date);
            const bonus = calculateBonus(4999.99, 100);
            expect(bonus).toBe(0);
        });
    })
    afterEach(() => {
        vi.useRealTimers();
    })
});