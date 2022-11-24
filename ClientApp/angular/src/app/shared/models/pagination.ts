import {Car} from "./car";

export interface IPagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: Car[];
}
