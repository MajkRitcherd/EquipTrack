import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DeviceService } from './services/device';
import { Device } from './models/device.model';

@Component({
  imports: [RouterOutlet],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App implements OnInit {
  private deviceService = inject(DeviceService);

  devices = signal<Device[]>([]);

  ngOnInit(): void {
    this.deviceService.getDevices().subscribe({
      next: (data) => this.devices.set(data),
      error: (err) => console.error('An error occurred when getting data: ', err)
    });
  }
}
