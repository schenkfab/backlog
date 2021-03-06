﻿using AutoMapper;
using backlog.Entities;
using backlog.Models;

namespace backlog.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserForCreationDto, User>();
            CreateMap<UserDto, User>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<SubscriptionDto, Subscription>();
            CreateMap<SubscriptionForCreationDto, Subscription>();
            CreateMap<Subscription, SubscriptionDto>();
            CreateMap<Feed, FeedDto>();
            CreateMap<FeedDto, Feed>();
            CreateMap<BoardItemDto, BoardItem>();
            CreateMap<BoardItem, BoardItemDto>();
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleDto, Article>();
            CreateMap<CollectionForCreationDto, Collection>();
            CreateMap<CollectionForUpdateDto, Collection>();
            CreateMap<CollectionDto, Collection>();
            CreateMap<CollectionForFeedDto, Collection>();
            CreateMap<Collection, CollectionDto>();
            CreateMap<Follow, FollowDto>();
            CreateMap<FollowDto, Follow>();
            CreateMap<FollowForSingleDto, Follow>();
            CreateMap<Follow, FollowForSingleDto>();
            CreateMap<FollowForUpdateDto, Follow>();
            CreateMap<FollowForCreationDto, Follow>();
            CreateMap<FeedInCollectionDto, FeedInCollection>();
            CreateMap<FeedInCollection, FeedInCollectionDto>();
            CreateMap<FeedInCollection, FeedInCollectionForFeedDto>();
            CreateMap<FeedInCollectionForFeedDto, FeedInCollection>();



        }
    }
}
