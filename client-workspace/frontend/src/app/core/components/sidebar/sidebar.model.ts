import {LucideIconData} from 'lucide-angular';


export interface SidebarItem {
  icon: LucideIconData;
  title: string;
  link: string;
  iconProps?: {
    size?: number;
    color?: string;
    strokeWidth?: number;
    absoluteStrokeWidth?: boolean;
  };
}
