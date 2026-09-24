import { Injectable, inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class DeviceService {
    private http = inject(HttpClient);

    getDevices(): Observable<any[]> {
        return this.http.get<any[]>('/api/devices');
    }
}