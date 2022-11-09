Vue.component('k-layout', {
    template:
        `
        <v-app>
            <v-app-bar app color="light-green darken-1 pa-0" height=75px>

                <v-app-bar-nav-icon class="green darken-4 white--text" @click="drawler = !drawler"></v-app-bar-nav-icon>
                <v-toolbar-title>
                    <h3 class="font-weight-bold mt-3 pt-2 white--text">BlogPost App</h3>
                    <p class="white--text">{{pageTitle}}</p>
                </v-toolbar-title>
                <v-spacer></v-spacer>
                <v-avatar size=48 class="mr-3">
                                <v-img :src=currentUserAvatar></v-img>
                </v-avatar>
                <v-menu offset-y v-if="currentUserName != ''" >
                    <template v-slot:activator="{ on, attrs }">
                        <v-btn class="green darken-4 white--text text-capitalize mr-3"
                            v-bind="attrs"
                            v-on="on">
                            {{currentUserName}}
                        </v-btn>
                    </template>
                    <v-list>
                        <v-list-item
                            v-for="(item, index) in userMenu"
                            :key="index">
                                <v-list-item-title>{{ item.title }}</v-list-item-title>
                        </v-list-item>
                    </v-list>
                </v-menu>
                <v-btn class="green darken-4 white--text text-capitalize" @click="testClick">
                    <span>{{signButtonText}}</span>
                    <v-icon right>mdi-login</v-icon>
                </v-btn>
            </v-app-bar>

            <v-navigation-drawer v-model="drawler" app class="light-green darken-1">
                <v-container>
                    <v-row>
                        <v-col>
                            <v-list>
                                <v-list-item class="text-right">
                                    <v-list-item-content>
                                        <v-spacer></v-spacer>
                                        <v-col>
                                            <v-btn fab small @click="drawler = !drawler" class="green darken-4 white--text">
                                            <v-icon>mdi-close</v-icon>
                                        </v-btn>
                                        </v-col>
                                    </v-list-item-content>
                                </v-list-item>
                                <v-list-item v-for="link, i in links" :key="i">
                                    <v-list-item-content>
                                        <v-btn :href=link.url class="green darken-4 white--text">
                                            <v-col> 
                                                <v-icon>{{link.icon}}</v-icon>
                                            </v-col>                                 
                                            <v-col>
                                                {{link.text}}
                                            </v-col>
                                        </v-btn>
                                    </v-list-item-content>
                                </v-list-item>
                            </v-list>
                        </v-col>
                    </v-row>
                </v-container>
            </v-navigation-drawer>

            <v-main class="lime lighten-4" >
                <slot ></slot>
            </v-main>

            <v-footer></v-footer>
        </v-app>
`,
    data() {
        return {
            drawler: false,
            actualSite: 'Home page',
            links: [
                { icon: 'mdi-home', text: 'Home', url: window.location.origin + '/Home/Index' },
                { icon: 'mdi-post-outline', text: 'Blog Posts', url: window.location.origin + '/BlogPosts/Index' },
                { icon: 'mdi-account-group', text: 'Users', url: window.location.origin + '/Users/Index' },
                { icon: 'mdi-email', text: 'Contact', url: window.location.origin + '/Contact/Index' },
            ],
            signInPage: `${window.location.origin}/Users/SignIn`,
            signButtonText: "",
            currentUserName: "",
            currentUserAvatar: "",
            userMenu: [
                { title: "My Account" },
                { title: "My Posts" },
                { title: "Other" }
            ]
            
        }
    },
    props: ["pageTitle", "aktualHost"],
    methods: {
        async testClick() {
            if (this.signButtonText == "SignIn") {
                window.location = `${window.location.origin}/Users/SignIn`
            }
            else {
                var response = await axios.get(`${window.location.origin}/Users/SignOut`);
                window.location = `${window.location.origin}/Home/Index`;
            }

        }
    },
    
    async mounted() {
        try {
            const response = await axios.get(`${window.location.origin}/Users/GetCurrentUser`);
            this.currentUserName = response.data.userName;
            this.currentUserAvatar = response.data.avatarLink;
            this.signButtonText = "SignOut";
        } catch (error) {
            this.signButtonText = "SignIn";
        }
    }
  
    
   
    
})

      