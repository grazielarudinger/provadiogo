import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { FormaPagamento } from "../models/forma";

@Injectable({
  providedIn: "root",
})
export class FormaService {
  private baseUrl = "http://localhost:5000/api/forma";

  constructor(private http: HttpClient) {}

  list(): Observable<FormaPagamento[]> {
    return this.http.get<FormaPagamento[]>(`${this.baseUrl}/list`);
  }
}
