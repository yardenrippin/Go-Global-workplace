import { Employee } from './Employee';

export interface  Manager {
    id: number;

    firstName: string;

    lastName: string;

    identityCard: string;

    Employee: Employee [];
}