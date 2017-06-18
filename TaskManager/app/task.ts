import { TaskState } from './taskState';

export class Task {
  id: number;
  name: string;
  description: string;
  state: TaskState;
  timeToComplete: string;
  priority: number; 
}


