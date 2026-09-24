export interface Device {
    id: string;
    manufacturer: string;
    model: string;
    displayName: string;
    serialNumber: string;
    state: string;
    userId: number | null;
    cpu: string | null;
    integratedGpu: string | null;
    dedicatedGpu: string | null;
    ramStorageInGB: number | null;
    storageInGb: number | null;
}