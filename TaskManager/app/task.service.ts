import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Task } from './task';

@Injectable()
export class TaskService {

  private headers = new Headers({'Content-Type': 'application/json'});
  private TaskesUrl = 'api/Task';  // URL to web api

  constructor(private http: Http) { }

  getTasks(): Promise<Task[]> {
    return this.http.get(this.TaskesUrl)
               .toPromise()
               .then(response => response.json().data as Task[])
               .catch(this.handleError);
  }


  getTask(id: number): Promise<Task> {
    const url = `${this.TaskesUrl}/${id}`;
    return this.http.get(url)
      .toPromise()
      .then(response => response.json().data as Task)
      .catch(this.handleError);
  }

  delete(id: number): Promise<void> {
    const url = `${this.TaskesUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
      .toPromise()
      .then(() => null)
      .catch(this.handleError);
  }

  create(name: string): Promise<Task> {
    return this.http
      .post(this.TaskesUrl, JSON.stringify({name: name}), {headers: this.headers})
      .toPromise()
      .then(res => res.json().data as Task)
      .catch(this.handleError);
  }

  update(Task: Task): Promise<Task> {
    const url = `${this.TaskesUrl}/${Task.id}`;
    return this.http
      .put(url, JSON.stringify(Task), {headers: this.headers})
      .toPromise()
      .then(() => Task)
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}

