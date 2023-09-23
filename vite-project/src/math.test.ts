import {describe, it, expect } from 'vitest';
import { add } from './math';

describe('Doing Math', () => {
    it('Can add two numbers', () => {

        const answer = add(2,2);
        expect(answer).toBe(4);
    });
})